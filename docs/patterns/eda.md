# EDA - Event Driven Architecture

## Decisão

Event-driven architecture (EDA), ou em português, arquitetura orientada a eventos ( EDA ) é um paradigma de arquitetura de software que promove a produção, detecção, consumo e reação a eventos.
Um evento pode ser definido como "uma mudança significativa no estado". Como por exemplo, no Projeto Pingr, tanto web quanto mobile têm um menu específico para listar as notificações, ordenadas da mais recente para a mais antiga. As notificações são diferenciadas entre “lidas” e “não lidas”, pode tratar essa mudança de estado como um evento cuja ocorrência pode ser divulgada para outros aplicativos da arquitetura. De uma perspectiva formal, o que é produzido, publicado, propagado é uma notificação (geralmente assíncrona) chamada de notificação de evento, e não o próprio evento.  Clientes mobile têm suporte a notificações PUSH que são enviadas assim que a ação ocorre (interação com pings, DPs, etc); 

Como cheguei a escolher essa decisão?

Usamos esse padrão em tais microsserviços:

* Microsserviço 1
* Microsserviço 2

## Consequências

Descrever pontos positivos e negativos de ter escolhido esse padrão
