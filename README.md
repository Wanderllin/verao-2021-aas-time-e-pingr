# PROGRAMA DE VERÃO (2021 - edição 50)

# verao-2021-aas-time-e-pingr
**Projeto Pingr - Arquitetura Ágil de Software - EaD - Período: 18/01/2021 a 26/02/2021**

Este é o repositório do github para a solução criada pela equipe E para o Projeto Pingr 2020. Ele contém uma proposta de arquitetura para a nova rede social Pingr, qhe recebeu um grande aporte financeiro na virada de 2020 para 2021 e também este novo planejamento tem como objetivo multiplicar a equipe de desenvolvimento - indo de 15 para 250 membros ao longo dos próximos 12 meses.

## Curso: 17. Arquitetura Ágil de Software - EaD
Professores: **João Francisco Lino Daniel, Thatiane de Oliveira Rosa e Wander Souza**

## Membros do time E:
* Denilson Costa Dias
* Guilherme Martelato Campos	
* Marcos Barbosa de Castro
* Renan Marcos Ferreira	
* Vanderlin Júnior	
* Victor Eduardo Próspero	

## 1. Infraestrutura

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
## 2. Análise de Requisitos Funcionais (RF) e Requisitos Não Funcionais (RNF)


## 3. História de usuário

**História de usuário:** especifica uma vontade de um conjunto de pessoas, podendo conter vários DoD (Definition of Done) com regras de negócio ou requisitos não funcionais
Usuário: ator que possui uma conta no sistema
Visitante: ator que não possui uma conta no sistema

**Histórias de usuários agrupadas por microsserviços**

**Conta**

**Eu, como usuário, gostaria de realizar o gerenciamento da minha conta**

  * Uma conta é identificável por nome de usuário
  * Uma conta está atrelada a uma senha e um e-mail
  * Posso alterar a privacidade da minha conta, sendo ela pública ou privada
    * Quando minha conta é pública, todos os meus novos pings entrarão com a visibilidade “público”
    * Quando minha conta é privada, preciso aceitar q
    * Quem quer me seguir ou não. Todos os meus novos pings entrarão com a visibilidade “privado”
  * Posso criar uma lista de “amigos especiais” no qual consigo adicionar um conjunto de usuários
Eu, como usuário, gostaria de criar novos pings
  * Um ping contém textos de no máximo 140 caracteres
  * Um ping não pode ser editado depois de postado, apenas apagado
  * É possível mencionar outro usuário no texto
  * Pode levar até 15 segundos para aparecer meu novo ping para mim
Eu, como usuário, gostaria de alterar a visibilidade de um ping antes de criá-lo
  * Por padrão, a visibilidade de um novo ping deve respeitar o que for definido nas configurações de privacidade da própria conta, como já foi mencionado
  * Um ping público é visto por outros usuários e por visitantes. Essa opção só fica disponível para contas com a privacidade marcada como “privada”
  * Um ping privado é visto somente por usuários que seguem a minha conta
  * Um ping restrito/privado aos amigos especiais é visto somente por essa lista de amigos pré selecionados nas configurações da conta. Essa opção só fica disponível para contas com a privacidade marcada como “pública”
Eu, como usuário, gostaria de classificar meus pings em até 10 hashtags (palavras chaves)
  * As hashtags não são contabilizadas na limitação de caracteres do ping
Eu, como usuário, gostaria de anexar imagens em um ping
Eu, como usuário, gostaria de responder pings
  * Podendo responder o próprio ping ou ping de outras pessoas
Eu, como usuário, gostaria de curtir um ping de outros usuários
Eu, como usuário, gostaria de compartilhar um ping
  * Essa ação é chamada de pong
Eu, como usuário, gostaria de ser notificado ao receber qualquer interação com minha conta
  * As interações possíveis são: compartilharam meu ping (pong), curtiram meu ping, responderam meu ping, começaram a seguir minha conta, mencionaram meu nome de usuário em algum ping, recebi uma nova mensagem privada (Direct Ping)
  * Quando a privacidade da conta é privada, recebo notificações com solicitação para me seguirem e posso responder aceitando ou não
  * Clientes mobile recebem notificações ASAP (As Soon As Possible) através do sistema de PUSH do Sistema Operacional
Eu, como usuário, gostaria de visualizar uma lista de notificações recebidas
  * É ordenado da mais recente para a mais antiga
  * Posso classificar uma notificação como “lida” ou “não lida” e essa separação é exibida na tela
Eu, como usuário, gostaria de visualizar pings na mesa principal (timeline)
  * É possível visualizar os próprios pings ou de outros usuários
  * Clientes no celular só conseguem ver essa mesa principal
  * Pode demorar até 3 minutos no máximo para aparecer novos pings de outros usuários nas mesas
Eu, como usuário, gostaria de visualizar pings utilizando filtros e salvar isso como uma mesa personalizada
  * Posso ter no máximo 3 mesas personalizadas
  * As mesas personalizadas só são visualizadas no cliente web
  * Posso usar como filtro hashtags e/ou nomes de usuários
Eu, como visitante, gostaria de visualizar pings públicos
Eu, como usuário, gostaria de seguir outros usuários
  * A relação de seguir não é espelhada (se A segue o B, não quer dizer que o B está seguindo o A)
  * Ao seguir um usuário, todos os novos pings publicados por ele e os antigos são exibidos nas mesas (log, histórico)
Eu, como usuário, gostaria de seguir hashtags
  * Os pings classificados com a hashtag seguida são exibidos nas mesas
Eu, como usuário, gostaria de visualizar pings associados a um hashtag (busca de hashtags)
Eu, como usuário, gostaria de visualizar as hashtags mais utilizadas no mundo todo 
  * Essa lista é chamada de TagNowWorld (TgNW) e é gerada a cada 10 minutos
  * Ao clicar para visualizar uma hashtag(#arquitetura) , a busca por pings com ela é disparada
Eu, como usuário, gostaria de visualizar as hashtags mais utilizadas localmente (estatística)
  * Essa lista é chamada de TagNowHere (TgNH), é gerada a cada 10 minutos e é baseada no sensor de GPS
  * Ao clicar para visualizar uma hashtag, a busca por pings com ela é disparada
  * Os filtros possíveis são: nacional, estadual e municipal
  * Caso não exista um acesso ao sensor de GPS, a lista não fica disponível?? Não dar a permissão do sensor de GPS, então fica inativo, sem acesso.
Eu, como usuário, gostaria de me comunicar com outro usuário de maneira privada através de mensagens
  * Essa comunicação é chamada de DP (Direct Ping)
  * Um DP não pode ser curtido e nem compartilhado
  * Apenas o destinatário pode responder a mensagem
  * Todas as outras restrições de um ping normal se aplicam aqui (texto limitado a 140 caracteres, não pode ser editado, é possível mencionar outro usuário)
  * Um DP possui status das mensagens: enviado, não recebido, recebido ou visualizado
  * Pode levar até 1 minuto para ser enviado, se após este tempo é não é reenviado/perdido (loop, caso não seja recebida, ainda)

## 4. Respondendo a que perguntas do Projeto **Projeto Pingr** 


## 5. Justificativas para o uso de CQRS

• Dimensionamento independente. O CQRS permite que as cargas de trabalho de leitura e gravação sejam dimensionadas de forma independente e pode resultar em menos contenções de bloqueio.

• Esquemas de dados otimizados. O lado de leitura pode usar um esquema que é otimizado para consultas, enquanto o lado de gravação usa um esquema que é otimizado para atualizações.

• Segurança. É mais fácil garantir que apenas as entidades do direito de domínio estejam executando gravações nos dados.

• Separação de preocupações. Isolar os lados de leitura e gravação pode resultar em modelos mais flexíveis e sustentáveis. A maior parte da lógica de negócios complexa vai para o modelo de gravação. O modelo de leitura pode ser relativamente simples.

• Consultas mais simples. Ao armazenar uma exibição materializada no banco de dados de leitura, o aplicativo poderá evitar junções complexas durante as consultas.
