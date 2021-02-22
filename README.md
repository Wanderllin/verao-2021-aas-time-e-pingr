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

## Requisitos Funcionais

(Requisito Funcional estamos nos referindo à requisição de uma função que um software deverá atender/realizar. Ou seja, exigência, solicitação, desejo, necessidade, que um software deverá materializar.Os requisitos funcionais podem ser cálculos, detalhes técnicos, manipulação de dados e de processamento e outras funcionalidades específicas que definem o que um sistema, idealmente, será capaz de realizar.)

**Cadastro de usuário**
 * RF001: Para poder pingar (postar pings), as pessoas precisam criar uma conta com e-mail, senha e um nome de usuário
  * E-mail deve ser único
  * Senha deve ser criptografada
 * RF002: Um usuário pode gerenciar a visibilidade de seus pings: Criar uma tabela para definir e separar o que é visibilidade do ping e o  que é visibilidade do perfil
  * Privado: Redefinir o padrão para privado e, nesse caso, outros usuários precisam solicitar permissão para segui-lo e assim poder ver e interagir com seus pings
  * Amigos especiais - Para quem é público: Marcar um ping como restrito aos amigos especiais, uma lista de usuários que seguem o usuário em questão e é pré-definida pelo mesmo (apenas no caso do padrão estar como público)
  * Ping Público - Para quem é privado: Marcar um ping como público (apenas no caso em que o padrão está como privado).

**REQUISITO 1: postar ping**
  * RF003: Um ping pode conter textos limitados a 140 caracteres e/ou imagens, e ainda pode ser classificado com até 10 palavras chaves (hashtags, que não são contabilizadas nos 140 caracteres). Os usuários podem fazer menções a outros usuários no formato @nomeDeUsuário.
   * Os textos podem conter um emoji unicode
   * Talvez colocar limite no anexo de imagens
   * Limitador de transferência de imagens
  * RF003: Um ping pode ser respondido com um novo ping por qualquer usuário do Pingr, inclusive o próprio autor.
  * RF004: Interações em pings geram notificações ao autor.
  * RF005: Por padrão, o conjunto de pings de um usuário é público 
  * RF006: Ao selecionar uma hashtag de alguma TgN (TagHereNow), uma busca é disparada por pings marcados com aquela palavra-chave.
  * RF007: Por padrão, o conjunto de pings de um usuário é público, que significa que qualquer pessoa -- mesmo sem ter um perfil no Pingr -- pode acessá-lo

**Direct Ping**
  * RF036: Outra forma de interagir pelo Pingr é através de Direct Ping (DP).
  * RF037: Enviar um DP é a forma de trocar mensagens com um outro usuário de forma privada.
  * RF038: Ao receber um DP, uma notificação é gerada para o usuário. 
  * RF039: Um DP não pode ser curtido nem receber pongs; apenas pode ser respondido. 
  * RF040: As demais restrições de um ping normal se aplicam a um DP.
   * Estágios de um DP
    * Enviado: quando a mensagem sai com sucesso do emissor;
    * Não-recebido: quando a mensagem é enviada, porém ocorreu alguma falha no caminho. Nesse caso, ela pode ser reenviada;
    * Recebido: quando a mensagem é enviada e recebida com sucesso; 
    * Visualizado: quando a mensagem é recebida e o usuário a abre.

**Postar**
  * RF008: Depois de postado, não pode mais ser editado
  * RF009: Pode apenas apagá-lo do histórico
 
**Pong**
  * RF010: Porém, apenas outros usuários podem curtir ou dar pong (compartilhar aquele ping). 
  * RF012: Um DP (Direct Ping) não pode ser curtido nem receber pongs; (mensagem privada)
   * Pode ser excluído?
   * Tem uma tela só para isso? Ou vai aparecer na mesa?
    
**Curtir?**
  * RF013: não achei a regra
   * Pode curtir mais de uma vez o mesmo ping?
   * Pode descurtir?

**Seguir**
  * RF014: Um usuário pode seguir outros usuários. 
  * RF015: Essa relação não é espelhada, isto é, quando um usuário A começa a seguir um usuário B, isto não significa que B começa a seguir A
  * RF016: Quando um usuário começa a seguir outro, uma notificação é gerada para o seguido
   * Quando começa a seguir, enxerga todo o histórico de ping’s ou só os novos?
  * RF017: Além de seguir usuários, também é possível seguir hashtags. 
  * RF018: Ao selecionar uma hashtag de alguma TgN, uma busca é disparada por pings marcados com aquela palavra-chave.

**Mesa principal - (destrinchar esse requisito)**
  * RF019: O conjunto histórico de pings dos usuários seguidos por um usuário é exibido em sua mesa principal (a linha do tempo).

**Mesas secundárias (views)**
  * RF020: Um usuário pode criar mesas secundárias personalizadas com filtros por grupo de usuários e/ou hashtags. O número máximo de mesas secundárias é 3.
  * RF021: As menções de outros usuários em um ping, geram notificações aos referidos usuários.
  * RF023: Quando um usuário A solicita seguir um usuário privado B, uma notificação é gerada para B.
  * RF024: Quando B decide a solicitação (seja aceitando ou recusando), uma notificação é gerada para A informando o ocorrido.
  * RF025: Ao receber um DP, uma notificação é gerada para o usuário. 
  * RF026: As notificações têm comportamentos diferentes dependendo do cliente (web ou mobile). Na web tem um menu para listar notificações. No mobile é ASAP (um push)
   * Na mesa terá notificação ao chegar novos ping’s?

**TagNows**
  * RF027: duas listas de palavras-chave mais utilizadas
   * Configuração
    * Opções selecionáveis da TgNH são nacional, estadual e municipal, de acordo com a localização do sensor de GPS. 
    * No caso de o usuário não ter acesso a um sensor GPS ou o usuário não ter dado permissão para acessar o mesmo, então a segunda lista de hashtags não fica disponível.
    * Aos usuários que acessam o Pingr pelo cliente web, a TgNH não está disponível, ela é exclusiva de clientes mobile.

**Serviço**
 * RF028: listas de palavras-chave mais utilizadas: 
 * TagNow World
  * A cada 10 minutos, são geradas a TagNow World (TgNW)
  * Lista global
   * Quantas tags?
   * Essa lista vai sendo consolidada ao longo dos 10 minutos para ficar disponível a consulta das mais utilizadas. O usuário sempre vê a última consolidação gerada
 * TagNow Here
  * A cada 10 minutos, são geradas a TagNow Here (TgNH)
  * Lista configurável por usuário.

**Web**
 * RF029: Aos usuários que acessam o Pingr pelo cliente web, a TgNH não está disponível 
 * RF030: A visualização de mesas personalizadas é restrita apenas a usuários acessando por clientes web. 
 * RF031: Tanto web quanto mobile têm um menu específico para listar as notificações, ordenadas da mais recente para a mais antiga. As notificações são diferenciadas entre “lidas” e “não lidas”. 

**Mobile**
 * RF032: Aos usuários que acessam o Pingr pelo cliente mobile, a TgNH está disponível 
 * RF033: Para clientes mobile, apenas a mesa principal é disponibilizada.
  * Comportamento das notificações:
   * Clientes mobile têm suporte a notificações PUSH que são enviadas assim que a ação ocorre (interação com pings, DPs, etc); 
 * RF034: Tanto web quanto mobile têm um menu específico para listar as notificações, ordenadas da mais recente para a mais antiga. As notificações são diferenciadas entre “lidas” e “não lidas”. 

**Busca hashtag**
 * RF035: Ao selecionar uma hashtag de alguma TgN, uma busca é disparada por pings marcados com aquela palavra-chave.

## Requisitos Não Funcionais
(requisito não funcional de software é aquele que descreve não o que o sistema fará, mas como ele fará. Assim, por exemplo, têm-se requisitos de desempenho, requisitos da interface externa do sistema, restrições de projeto e atributos da qualidade. Exemplo destes requisitos são desempenho, portabilidade, manutenibilidade e escalabilidade.)

**Tipos de dispositivos**
 * RNF01: web
 * RNF02: mobile
  
**Hardware/portabilidade**
 * RNF03: O aporte financeiro possibilitou a mudança de escritório para um novo lugar
  * Lei Conway e times interdisciplinares correspondem a mudança de lugar que a empresa está passando, ao crescimento do time
  
**Escalabilidade**
 * RNF04: O Pingr é acessado maciçamente por seu público ao longo das 24/7.
  * Canary deployment para não atualizar toda a base de usuários de uma vez.
  * Utilização de TDD para prevenir erros
  * A/B Testing
  
**Eficiência**
  * RNF05: usuários toleram alguns delays nas atualizações:
   * Pings de outros podem demorar até 3 minutos para aparecer na(s) sua(s) mesa(s); 
   * DPs podem levar até 1 minuto para serem recebidos;
   * Pings próprios podem levar até 15s para aparecerem para si.

**Entrega**
  * RNF06: Até 4 meses atrás, a empresa Pingr investiu apenas no público latino-americano. 
  * RNF07: Até julho de 2022, o plano é de ter presença em países de todos os continentes.

**Time**
  * RNF08: O planejamento é multiplicar a equipe de desenvolvimento 
  * RNF09: indo de 15 para 250 membros ao longo dos próximos 12 meses. 
  * RNF10: Os times serão autogerenciáveis e multidisciplinares

**Legais**
  * RNF11: Durante sua criação e crescimento inicial, o Pingr passou pela aprovação em uma consultoria sobre LGPD.
  * RNF12: O novo sistema deve manter o mesmo patamar em conformidade com as novas diretrizes de segurança de dados pessoais. (informar sobre vazamento de dados pessoais)
  
**padrões**
  * RNF13: O Pingr sempre foi desenvolvido sob as práticas de Engenharia de Software Ágil e assim deverá se manter durante a expansão da equipe.

**Implantação**
  * RNF14: sistema seja testável, desde suas unidades até a integração das partes.
  * RNF15: Além disso, deve ser possível fazer testes A/B com usuários para o lançamento de novas funcionalidades,
  * RNF16: implantação canária (canary deployment) e demais técnicas semelhantes. 


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
   
**Eu, como usuário, gostaria de criar novos pings**
  * Um ping contém textos de no máximo 140 caracteres
  * Um ping não pode ser editado depois de postado, apenas apagado
  * É possível mencionar outro usuário no texto
  * Pode levar até 15 segundos para aparecer meu novo ping para mim
   
**Eu, como usuário, gostaria de alterar a visibilidade de um ping antes de criá-lo**
  * Por padrão, a visibilidade de um novo ping deve respeitar o que for definido nas configurações de privacidade da própria conta, como já foi mencionado
  * Um ping público é visto por outros usuários e por visitantes. Essa opção só fica disponível para contas com a privacidade marcada como “privada”
  * Um ping privado é visto somente por usuários que seguem a minha conta
  * Um ping restrito/privado aos amigos especiais é visto somente por essa lista de amigos pré selecionados nas configurações da conta. Essa opção só fica disponível para contas com a privacidade marcada como “pública”
   
**Eu, como usuário, gostaria de classificar meus pings em até 10 hashtags (palavras chaves)**
  * As hashtags não são contabilizadas na limitação de caracteres do ping
  
**Eu, como usuário, gostaria de anexar imagens em um ping**

**Eu, como usuário, gostaria de responder pings**
  * Podendo responder o próprio ping ou ping de outras pessoas
   
**Eu, como usuário, gostaria de curtir um ping de outros usuários**

**Eu, como usuário, gostaria de compartilhar um ping**
  * Essa ação é chamada de pong
   
**Eu, como usuário, gostaria de ser notificado ao receber qualquer interação com minha conta**
  * As interações possíveis são: compartilharam meu ping (pong), curtiram meu ping, responderam meu ping, começaram a seguir minha conta, mencionaram meu nome de usuário em algum ping, recebi uma nova mensagem privada (Direct Ping)
  * Quando a privacidade da conta é privada, recebo notificações com solicitação para me seguirem e posso responder aceitando ou não
  * Clientes mobile recebem notificações ASAP (As Soon As Possible) através do sistema de PUSH do Sistema Operacional
   
**Eu, como usuário, gostaria de visualizar uma lista de notificações recebidas**
  * É ordenado da mais recente para a mais antiga
  * Posso classificar uma notificação como “lida” ou “não lida” e essa separação é exibida na tela
   
**Eu, como usuário, gostaria de visualizar pings na mesa principal (timeline)**
  * É possível visualizar os próprios pings ou de outros usuários
  * Clientes no celular só conseguem ver essa mesa principal
  * Pode demorar até 3 minutos no máximo para aparecer novos pings de outros usuários nas mesas
  
**Eu, como usuário, gostaria de visualizar pings utilizando filtros e salvar isso como uma mesa personalizada**
  * Posso ter no máximo 3 mesas personalizadas
  * As mesas personalizadas só são visualizadas no cliente web
  * Posso usar como filtro hashtags e/ou nomes de usuários
  
**Eu, como visitante, gostaria de visualizar pings públicos**

**Eu, como usuário, gostaria de seguir outros usuários**
  * A relação de seguir não é espelhada (se A segue o B, não quer dizer que o B está seguindo o A)
  * Ao seguir um usuário, todos os novos pings publicados por ele e os antigos são exibidos nas mesas (log, histórico)
  
**Eu, como usuário, gostaria de seguir hashtags**
  * Os pings classificados com a hashtag seguida são exibidos nas mesas
  
**Eu, como usuário, gostaria de visualizar pings associados a um hashtag (busca de hashtags)**

**Eu, como usuário, gostaria de visualizar as hashtags mais utilizadas no mundo todo**
  * Essa lista é chamada de TagNowWorld (TgNW) e é gerada a cada 10 minutos
  * Ao clicar para visualizar uma hashtag(#arquitetura) , a busca por pings com ela é disparada

**Eu, como usuário, gostaria de visualizar as hashtags mais utilizadas localmente (estatística)**
  * Essa lista é chamada de TagNowHere (TgNH), é gerada a cada 10 minutos e é baseada no sensor de GPS
  * Ao clicar para visualizar uma hashtag, a busca por pings com ela é disparada
  * Os filtros possíveis são: nacional, estadual e municipal
  * Caso não exista um acesso ao sensor de GPS, a lista não fica disponível?? Não dar a permissão do sensor de GPS, então fica inativo, sem acesso.
  
**Eu, como usuário, gostaria de me comunicar com outro usuário de maneira privada através de mensagens**
  * Essa comunicação é chamada de DP (Direct Ping)
  * Um DP não pode ser curtido e nem compartilhado
  * Apenas o destinatário pode responder a mensagem
  * Todas as outras restrições de um ping normal se aplicam aqui (texto limitado a 140 caracteres, não pode ser editado, é possível mencionar outro usuário)
  * Um DP possui status das mensagens: enviado, não recebido, recebido ou visualizado
  * Pode levar até 1 minuto para ser enviado, se após este tempo é não é reenviado/perdido (loop, caso não seja recebida, ainda)

## 4. Respondendo a que perguntas do Projeto **Projeto Pingr** 

**TRADE OFF dos Pings**

  Como a equipe de desenvolvimento vai crescer e os pings são muito importantes para os usuários.  
  Aplicamos o padrão de arquitetura CQRS para os Pings.  
  Onde teremos um microsserviço chamado ping-query, que fará todas as consultas em um repositório replicado.  
  E outro microsserviço chamado ping-command, onde faremos todas as postagens de pings dos usuários com um banco próprio.  
  Entre os dois microsserviços existirá um mecanismo de ETL que irá gravar na base do "ping-query" de forma estruturada as informações para as consultas apropriadas a esse serviço.  
  A seguir algumas definições da história do usuário.  

* Ping Privado
 
  Um ping privado é visto somente por usuários que seguem a minha conta.  
  Um ping de uma conta privada, pode ser alterada para pública e visto por outros usuários e por visitantes.  

* Ping Público

  Eu, como visitante, gostaria de visualizar pings públicos.  
  Um ping público é visto por outros usuários e por visitantes.  
  Quando minha conta é pública, todos os meus novos pings entrarão com a visibilidade “público”.  

* Ping

  Pode levar até 15 segundos para aparecer meu novo ping para mim.  
  Eu, como usuário, gostaria de classificar meus pings em até 10 hashtags.  
  Eu, como usuário, gostaria de anexar imagens em um ping.  
  Eu, como usuário, gostaria de responder pings. Podendo responder o próprio ping ou ping de outras pessoas.  
  Eu, como usuário, gostaria de curtir um ping.  
  Eu, como usuário, gostaria de compartilhar um ping. Essa ação é chamada de pong.  

* Mesa Principal

  Eu, como usuário, gostaria de visualizar pings na mesa principal (timeline).  
  É possível visualizar os próprios pings ou de outros usuários.  
  Pode demorar até 3 minutos no máximo para aparecer novos pings de outros usuários nas mesas.  
  Ao seguir um usuário, todos os novos pings publicados por ele e os antigos são exibidos nas mesas.  
  Os pings classificados com a hashtag seguida são exibidos nas mesas.  

* Mesa Personalizada

  Eu, como usuário, gostaria de visualizar pings utilizando filtros e salvar isso como uma mesa personalizada.  
  Posso ter no máximo 3 mesas personalizadas.  
  As mesas personalizadas só são visualizadas no cliente web.  
  Usar como filtro hashtags e/ou nomes de usuários.  
  Ao seguir um usuário, todos os novos pings publicados por ele e os antigos são exibidos nas mesas.  
  Os pings classificados com a hashtag seguida são exibidos nas mesas.  

* Consulta pings por HashTag

  Eu, como usuário, gostaria de visualizar pings associados a um hashtag (busca de hashtags).  
  Na lista das TgNW e TgNH Ao clicar para visualizar uma hashtag, a busca por pings com ela é disparada.  


## 5. Justificativas para o uso de CQRS

• Dimensionamento independente. O CQRS permite que as cargas de trabalho de leitura e gravação sejam dimensionadas de forma independente e pode resultar em menos contenções de bloqueio.

• Esquemas de dados otimizados. O lado de leitura pode usar um esquema que é otimizado para consultas, enquanto o lado de gravação usa um esquema que é otimizado para atualizações.

• Segurança. É mais fácil garantir que apenas as entidades do direito de domínio estejam executando gravações nos dados.

• Separação de preocupações. Isolar os lados de leitura e gravação pode resultar em modelos mais flexíveis e sustentáveis. A maior parte da lógica de negócios complexa vai para o modelo de gravação. O modelo de leitura pode ser relativamente simples.

• Consultas mais simples. Ao armazenar uma exibição materializada no banco de dados de leitura, o aplicativo poderá evitar junções complexas durante as consultas.
