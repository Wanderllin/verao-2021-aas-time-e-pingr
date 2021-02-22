# Histórias de usuário

Especifica uma vontade de um conjunto de pessoas no contexto da solução, podendo conter vários _DoD (Definition of Done)_ com requisitos funcionais/não funcionais.

## Definições dos atores

**Usuário**: ator que possui uma conta na rede social

**Visitante**: ator que não possui uma conta na rede social

### Eu, como usuário, gostaria de realizar o gerenciamento da minha conta

* Uma conta é identificável por nome de usuário
* Uma conta está atrelada a uma senha e um e-mail
* Posso alterar a privacidade da minha conta, sendo ela pública ou privada
  * Quando minha conta é pública, todos os meus novos pings entrarão com a visibilidade “público”
  * Quando minha conta é privada, preciso aceitar quem quer me seguir ou não. Todos os meus novos pings entrarão com a visibilidade “privado”
* Posso criar uma lista de “amigos especiais” no qual consigo adicionar um conjunto de usuários

### Eu, como usuário, gostaria de criar novos pings

* Um ping contém textos de no máximo 140 caracteres
* Um ping não pode ser editado depois de postado, apenas apagado
* É possível mencionar outro usuário no texto
* Pode levar até 15 segundos para aparecer meu novo ping para mim

### Eu, como usuário, gostaria de alterar a visibilidade de um ping antes de criá-lo

* Por padrão, a visibilidade de um novo ping deve respeitar o que for definido nas configurações de privacidade da própria conta, como já foi mencionado
  * Um ping público é visto por outros usuários e por visitantes. Essa opção só fica disponível para contas com a privacidade marcada como “privada”
  * Um ping privado é visto somente por usuários que seguem a minha conta
  * Um ping restrito/privado aos amigos especiais é visto somente por essa lista de amigos pré selecionados nas configurações da conta. Essa opção só fica disponível para contas com a privacidade marcada como “pública”

### Eu, como usuário, gostaria de classificar meus pings em até 10 hashtags (palavras chaves)

* As hashtags não são contabilizadas na limitação de caracteres do ping
  
### Eu, como usuário, gostaria de anexar imagens em um ping

### Eu, como usuário, gostaria de responder pings

* Podendo responder o próprio ping ou ping de outras pessoas

### Eu, como usuário, gostaria de curtir um ping de outros usuários

### Eu, como usuário, gostaria de compartilhar um ping

* Essa ação é chamada de pong

### Eu, como usuário, gostaria de ser notificado ao receber qualquer interação com minha conta

* As interações possíveis são: compartilharam meu ping (pong), curtiram meu ping, responderam meu ping, começaram a seguir minha conta, mencionaram meu nome de usuário em algum ping, recebi uma nova mensagem privada (Direct Ping)
* Quando a privacidade da conta é privada, recebo notificações com solicitação para me seguirem e posso responder aceitando ou não
* Clientes mobile recebem notificações ASAP (As Soon As Possible) através do sistema de PUSH do Sistema Operacional

### Eu, como usuário, gostaria de visualizar uma lista de notificações recebidas

* É ordenado da mais recente para a mais antiga
* Posso classificar uma notificação como “lida” ou “não lida” e essa separação é exibida na tela

### Eu, como usuário, gostaria de visualizar pings na mesa principal

* É possível visualizar os próprios pings ou de outros usuários
* Clientes no celular só conseguem ver essa mesa principal
* Pode demorar até 3 minutos no máximo para aparecer novos pings de outros usuários nas mesas
  
### Eu, como usuário, gostaria de visualizar pings utilizando filtros e salvar isso como uma mesa personalizada

* Posso ter no máximo 3 mesas personalizadas
* As mesas personalizadas só são visualizadas no cliente web
* Posso usar como filtro hashtags e/ou nomes de usuários
  
### Eu, como visitante, gostaria de visualizar pings públicos

### Eu, como usuário, gostaria de seguir outros usuários

* A relação de seguir não é espelhada (se A segue o B, não quer dizer que o B está seguindo o A)
* Ao seguir um usuário, todos os novos pings publicados por ele e os antigos são exibidos nas mesas
  
### Eu, como usuário, gostaria de seguir hashtags

* Os pings classificados com a hashtag seguida são exibidos nas mesas
  
### Eu, como usuário, gostaria de visualizar pings associados a um hashtag (busca de hashtags)

### Eu, como usuário, gostaria de visualizar as hashtags mais utilizadas no mundo todo

* Essa lista é chamada de TagNowWorld (TgNW) e é gerada a cada 10 minutos
* Ao clicar para visualizar uma hashtag, a busca por pings com ela é disparada

### Eu, como usuário, gostaria de visualizar as hashtags mais utilizadas localmente

* Essa lista é chamada de TagNowHere (TgNH), é gerada a cada 10 minutos e é baseada no sensor de GPS
  * Ao clicar para visualizar uma hashtag, a busca por pings com ela é disparada
  * Os filtros possíveis são: nacional, estadual e municipal
  * Caso não exista um acesso ao sensor de GPS, a lista não fica disponível
  
### Eu, como usuário, gostaria de me comunicar com outro usuário de maneira privada através de mensagens

* Essa comunicação é chamada de DP (Direct Ping)
* Um DP não pode ser curtido e nem compartilhado
* Apenas o destinatário pode responder a mensagem
* Todas as outras regras de um ping normal se aplicam aqui
* Um DP possui status das mensagens: enviado, não recebido, recebido ou visualizado
* Pode levar até 1 minuto para ser enviado
