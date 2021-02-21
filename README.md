# PROGRAMA DE VERÃO (2021 - edição 50)

# verao-2021-aas-time-e-pingr
Projeto Pingr - Arquitetura Ágil de Software - EaD - Período: 18/01/2021 a 26/02/2021

Este é o repositório do github para a solução criada pela equipe E para o Projeto Pingr 2020. Ele contém uma proposta de arquitetura para a nova rede social Pingr, qhe recebeu um grande aporte financeiro na virada de 2020 para 2021 e também este novo planejamento tem como objetivo multiplicar a equipe de desenvolvimento - indo de 15 para 250 membros ao longo dos próximos 12 meses.

## Curso: 17. Arquitetura Ágil de Software - EaD
Professores: João Francisco Lino Daniel, Thatiane de Oliveira Rosa, Wander

## Membros do time E:
* Denilson Costa Dias
* Guilherme Martelato Campos	
* Marcos Barbosa de Castro
* Renan Marcos Ferreira	
* Vanderlin Júnior	
* Victor Eduardo Próspero	

## Infraestrutura

Para subir a infraestrutura, basta instalar o Docker e depois digitar na linha de comando de um shell estando na pasta do projeto:

`docker-compose up -d`

### RabbitMQ (tecnologia responsável pelas filas da aplicação)

Possui interface de gerenciamento, acessada na seguinte URL (usuário e senha igual de aplicação)

`localhost:15672`

Dados para aplicações acessarem o RabbitMQ:

```txt
localhost:5672
Virtual Host (vhost): /
Usuário: pingr
Senha: pingr
```

### MariaDB (tecnologia responsável por ser o banco de dados estruturado das aplicações, é um clone do MySQL)

Não possui interface de gerenciamento

```txt
accounts-db
localhost:1433
Nome do banco: mysql
Usuário: root
Senha: 123

notifications-db
localhost:1434
Nome do banco: mysql
Usuário: root
Senha: 123

pings-db
localhost:1435
Nome do banco: mysql
Usuário: root
Senha: 123

statistics-db
localhost:1436
Nome do banco: mysql
Usuário: root
Senha: 123
```

### MinIO (tecnologia responsável por ser o banco de dados não estruturado das aplicações, é como se fosse um Blob Storage, onde guarda imagens)

Possui uma interface de usuário e o acesso é feito com a mesma porta do acesso a aplicação

```txt
localhost:9000
Usuário (Access Key): accesskey
Senha (Secret Key): secretkey
```

### Redis (tecnologia responsável por ser o banco de dados de caching das aplicações)

Não possui interface de gerenciamento

```txt
localhost:6379
Não possui senha
```

## Justificativas para o uso de CQRS

• Dimensionamento independente. O CQRS permite que as cargas de trabalho de leitura e gravação sejam dimensionadas de forma independente e pode resultar em menos contenções de bloqueio.

• Esquemas de dados otimizados. O lado de leitura pode usar um esquema que é otimizado para consultas, enquanto o lado de gravação usa um esquema que é otimizado para atualizações.

• Segurança. É mais fácil garantir que apenas as entidades do direito de domínio estejam executando gravações nos dados.

• Separação de preocupações. Isolar os lados de leitura e gravação pode resultar em modelos mais flexíveis e sustentáveis. A maior parte da lógica de negócios complexa vai para o modelo de gravação. O modelo de leitura pode ser relativamente simples.

• Consultas mais simples. Ao armazenar uma exibição materializada no banco de dados de leitura, o aplicativo poderá evitar junções complexas durante as consultas.
