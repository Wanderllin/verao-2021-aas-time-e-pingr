# Database per Service

## Decisão

A fim de garantir o desacoplamento entre os microsserviços, de forma que eles possam ser entregues independentemente uns dos outros pelos diferentes times, optou-se por utilizar um banco de dados por microsserviço. Isso também possibilita utilizar os bancos de dados mais adequados para as necessidades de armazenamento de cada serviço em particular.

Usamos esse padrão nos microsserviços:

* account
* ping-command
* ping-query
* statistic
* notification-delivery

## Consequências

Pontos positivos:

* Promove o desacoplamento entre microsserviços;
* Permite utilizar a forma mais adequada de armazenamento para situação;

Pontos negativos:

* Aumento da complexidade da solução, tanto para implementação quanto para gestão de diferentes bases de dados;
