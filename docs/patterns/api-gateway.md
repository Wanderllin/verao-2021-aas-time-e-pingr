# API Gateway

## Decisão

Para executar diferentes ações de usuários, diferentes microserviços precisam ser envolvidos, os quais precisariam ficar expostos para os clientes web e mobile, podendo tornar a solução mais suscetível a falhas de segurança e aumentando a complexidade de implementação dos clientes.

Para simplificar esse cenário, optou-se por usar um api-gateway. Com ele, a comunicação dos clientes web e mobile com os servidores pode ser centralizada em somente 2 pontos.

Usamos esse padrão nos microsserviços:

* web-api-gateway
* mobile-api-gateway

## Consequências

Pontos positivos:
 
* As aplicações cliente não sabem que a solução está organizada em múltiplos microsserviços; 
* Reduz a quantidade de chamadas para os servidores de aplicação;

Pontos negativos:

* Aumenta a complexidade da solução, por ser mais um item que precisa ser implementado;
