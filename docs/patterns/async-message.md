# Asynchronous message

## Decisão

É possível que certas operações no sistema não possam ser processadas rapidamente pelo sistema e os usuários não podem ficar esperando elas finalizarem para continuar usando o Pingr. Além disso, há uma tolerância para que os usuários vejam o efeito de certas ações. É o caso do envio de notificações para os usuários, a visualização de pings de outros usuários e a consulta dos TagNow (Here e World).

Para atender os cenários onde um serviço não precisa esperar o outro para continuar a sua execução, é feita uma comunicação assíncrona entre alguns serviços, por meio de canais dedicados para registro de certos eventos, como a postagem de um ping e o registro de algum tipo de interação entre usuários (com menção a um outro usuário num ping).

Usamos esse padrão para fazer a comunicação entre os seguintes microsserviços:

* ping-command e statistics
* ping-command e notification-delivery
* account e notification-delivery

## Consequências

Pontos positivos:

* Desacopla o serviço produtor de um evento dos serviços consumidores do evento;
* Aumenta a disponibilidade dos serviços, uma vez que o serviço produtor não precisa aguardar o processamento do evento no serviço consumidor;

Pontos negativos:

* Aumento da complexidade da solução;
* Canais de comunicação devem ser altamente disponíveis;
