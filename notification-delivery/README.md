# Instalação

## NodeJS
Para rodar o programa é necessário ter o NodeJS instalado. O instalador pode ser encontrado no endereço abaixo:
```txt
https://nodejs.org/en/download/
```

## Dependências do projeto.
Para instalar as dependências, navegue para o diretório deste projeto no prompt de comando e rode os comandos abaixo:
```txt
npm install express
npm install cors
npm install body-parser
npm install amqplib
```

# Configuração
Logo nas primeiras linhas do arquivo ```index.js``` existem três variáveis de configuração:
- ```httpPort``` indica em qual porta o endpoint do serviço está configurado para responder. Valor-padrão = 3000;
- ```allowedOrigins``` é um array com as url que têm permissão para acessar o microsserviço. Se este array estiver vazio, o microsserviço poderá ser acessado por qualquer url de origem. Valor-padrão = ["chrome-extension:", "://localhost"];
- ```queueReadDelay``` O programa verifica continuamente se existem mensagens assíncronas para serem processadas. Esta variável configura o tempo (em milissegundos) que leva para o programa verificar se existe uma próxima mensagem a ser lida. Valor-padrão = 1000;
Nas primeiras linhas do arquivo ```queue.js``` existem duas variáveis de configuração:
- ```rabbitMQUrl``` indica os dados de conexão com o rabbitMQ. Valor-padrão = "pingr:pingr@localhost:15672/vhost";
- ```rabbitMQChannel``` indica o nome da fila de mensagens assíncronas que o programa irá processar. Valor-padrão = "profile-interactions";

# Execução
Para rodar o programa, com o prompt de comando ainda no diretório deste projeto, rode o comando abaixo:
```txt
node index
```
No momento em que o programa está em execução, ele já inicia o processamento da fila de mensagens assíncronas e já disponiibiliza o seu microsserviço de busca de notificações.

Para chamar por esta busca, deve ser chamado o endpoint ```http://localhost:{{porta configurada}}/getNotifications``` via POST, enviando pelo body a estrutura abaixo:
```txt
{
    "userId": "2"
}
```
Este serviço retornará as notificações em que o usuario identificado por ```"userId"``` é o destinatário. Segue abaixo um exemplo do retorno deste microsserviço:
```txt
[
    {
        "event": "NewFollower",
        "originUserId": "1",
        "destinationUserId": "2"
    },
    {
        "event": "NewFollower",
        "originUserId": "3",
        "destinationUserId": "2"
    }
]
```

# Demais Notas

## Persistência
Por falta de tempo, não foi implementada a persistência no banco de dados, mas para efeito de teste foi feita uma persistência na variável ```receivedMessages``` do arquivo queue.js.

## Testes
Como eu tive alguns problemas para configurar o ambiente de desenvolvimento, eu não pude testar o processamento da fila assíncrona. Testei somente o microsserviço que retorna as notificações.
