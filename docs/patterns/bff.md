# BFF - Backends For Frontends

## Decisão

Uma arquitetura Backend for Frontend (BFF) pode ser usada para criar back-ends para aplicativos móveis ou web voltados para o cliente. Os BFFs podem ajudar a dar suporte a um aplicativo com vários clientes enquanto, ao mesmo tempo, movem o sistema para um estado menos acoplado do que um sistema monolítico. Este padrão de código ajuda as equipes a iterar recursos com mais rapidez e ter controle sobre os back-ends de aplicativos móveis sem afetar a experiência de um aplicativo móvel ou web correspondente. Uma arquitetura de microsserviço permite que as equipes iterem rapidamente e desenvolvam tecnologia para escalar rapidamente. A arquitetura Backend for Frontend (BFF) é um tipo de padrão criado com microsserviços. O principal componente desse padrão é um aplicativo que conecta o front-end do seu aplicativo ao back-end.

Este microsserviço se encaixa perfeitamente no projeto Pingr, pois está previsto pelo uso de clientes web e clientes mobile, para funcionalidades de postar pings, consulta de lista de hashtags, a visualização de mesas personalizadas é restrita apenas a usuários acessando por clientes web. Para clientes mobile, apenas a mesa principal é disponibilizada. Clientes mobile têm suporte a notificações PUSH que são enviadas assim que a ação ocorre (interação com pings, DPs, etc); Tanto web quanto mobile têm um menu específico para listar as notificações, ordenadas da mais recente para a mais antiga. As notificações são diferenciadas entre “lidas” e “não lidas”.

Este padrão de código o ajudará a:

  * Construir o padrão de arquitetura Backend for Frontend (BFF);
  * Gere um aplicativo em Node.js, Swift ou Java;
  * Gere um aplicativo com arquivos para implantação em Kubernetes, Cloud Foundry ou DevOps Pipeline;
  * Gere um aplicativo com arquivos para monitoramento e rastreamento distribuído;
  * Conecte-se a serviços provisionados;

**Usamos esse padrão em tais microsserviços:**

Plataformas de experiência do usuário como Mobile e Web Apps, que podem ser suportadas em linguagens como Node.js, Java ou Swift, se comunicam com seu próprio back-end para o servidor front-end, a fim de reunir as APIs apropriadas e as solicitações de serviço necessárias.
Cada back-end para front-end chama os serviços necessários que são solicitados pelo front-end.

Usamos esse padrão nos microsserviços:

* web-api-gateway

## Consequências

(Descrever pontos positivos e negativos de ter escolhido esse padrão)

As vantagens de usar a abordagem de microsserviços vão além de um desenvolvimento mais rápido. Com ela, podemos contar também com mais flexibilidade, resiliência e escalibilidade, além de uma manutenção bem mais fácil. 

**Pontos positivos do padrão de Gateway de API**

  * O gateway da API fica entre os aplicativos cliente e os microsserviços. Ele atua como um proxy reverso, encaminhando as solicitações de clientes para serviços. Ele também pode fornecer outros recursos de corte cruzado, como autenticação, terminação de SSL e cache.

  * O padrão chamado "back-end para front-end" (BFF), em que cada gateway de API pode fornecer uma API diferente adaptada para cada tipo de aplicativo cliente, possivelmente mesmo com base no fator forma de cliente implementando um código de adaptador específico que, sob a chamada de vários microserviços internos.

**Pontos negativos do padrão de Gateway de API**

   * A desvantagem mais importante é que, quando você implementa um Gateway de API, está acoplando essa camada aos microsserviços internos. Um acoplamento como este pode introduzir problemas sérios no seu aplicativo. Clemens Vaster, arquiteto na equipe do Barramento de Serviço do Azure, refere-se a essa possível dificuldade como "o novo ESB" na sessão "Mensagens e microsserviços" na GOTO 2016.

   * Usar um Gateway de API de microsserviços cria um possível ponto único de falha adicional.

   * Um Gateway de API pode apresentar um maior tempo de resposta devido à chamada de rede adicional. No entanto, essa chamada extra normalmente causa um menor impacto do que ter uma interface do cliente com excesso de chamadas diretas aos microsserviços internos.

   * Se não for dimensionado corretamente, o Gateway de API poderá se tornar um gargalo.

   * Um Gateway de API requer custos adicionais de desenvolvimento e manutenção futura se incluir lógica personalizada e agregação de dados. Os desenvolvedores precisam atualizar o Gateway de API para expor os pontos de extremidade de cada microsserviço. Além disso, as alterações de implementação nos microsserviços internos podem causar alterações de código no nível do Gateway da API. No entanto, se o Gateway de API estiver apenas aplicando segurança, logon e controle de versão (como ao usar o Gerenciamento de API do Azure), esse custo de desenvolvimento adicional poderá não se aplicar.

   * Se o Gateway de API for desenvolvido por uma única equipe, poderá haver um gargalo de desenvolvimento. Esse aspecto é outro motivo pelo qual uma abordagem melhor é ter vários gateways de API multas que respondem a diferentes necessidades do cliente. Você também pode separar o Gateway de API internamente em várias áreas ou camadas de propriedade de diferentes equipes trabalhando em microsserviços internos.

