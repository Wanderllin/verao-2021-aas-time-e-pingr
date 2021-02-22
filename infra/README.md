# Infraestrutura

Para subir a infraestrutura localmente, basta instalar o Docker e depois digitar na linha de comando de um shell estando na pasta do projeto:

`docker-compose up -d`

## RabbitMQ

Tecnologia responsável pelas filas da aplicação

Possui interface de gerenciamento, acessada na seguinte URL (usuário e senha igual de aplicação)

`localhost:15672`

Dados para aplicações acessarem o RabbitMQ:

```txt
localhost:5672
Virtual Host (vhost): /
Usuário: pingr
Senha: pingr
```

## MariaDB

Tecnologia responsável por ser o banco de dados estruturado das aplicações, é um clone do MySQL

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

## MinIO

Tecnologia responsável por ser o banco de dados não estruturado das aplicações, é como se fosse um Blob Storage, onde guarda imagens

Possui uma interface de usuário e o acesso é feito com a mesma porta do acesso a aplicação

```txt
localhost:9000
Usuário (Access Key): accesskey
Senha (Secret Key): secretkey
```

## Redis

Tecnologia responsável por ser o banco de dados de caching das aplicações

Não possui interface de gerenciamento

```txt
localhost:6379
Não possui senha
```
