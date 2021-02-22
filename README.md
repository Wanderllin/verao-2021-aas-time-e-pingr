# PROGRAMA DE VERÃO DO IME-USP (2021 - edição 50)

## Curso: Arquitetura Ágil de Software - EaD - Período: 18/01/2021 a 26/02/2021

Professores: **João Francisco Lino Daniel, Thatiane de Oliveira Rosa e Wander Souza**

### Membros do time E

* [Denilson Costa Dias](https://github.com/denilsoncd)
* [Guilherme Martelato Campos](https://github.com/guilhermemcampos)
* [Marcos Barbosa de Castro](https://github.com/marbarbosa)
* [Renan Marcos Ferreira](https://github.com/renanmarcos)
* [Vanderlin Júnior](https://github.com/Wanderllin)
* [Victor Eduardo Próspero](https://github.com/victorprospero)

## Pingr

Solução arquitetural criada pela equipe E para a rede social "Pingr", um microblog fictício parecido com o Twitter. Trabalhamos como uma consultoria técnica para modelar algo que se adequasse ao momento de ascensão da startup e implementando uma prova de conceito.

## Contexto do problema

Destrinchamos o [enunciado original](docs/enunciado-original.pdf) do projeto em [histórias de usuário](docs/historias-usuario.md) para facilitar o entendimento e compreensão do contexto do problema. Foi identificado também [atributos de qualidade](docs/atributos-qualidade.md) que não estavam diretamente relacionados a uma história de usuário.

## Solução adotada

Acreditamos que o modelo de microsserviços se encaixou perfeitamente no contexto por proporcionar maior granularidade no espaço da solução, fornecendo confortavelmente flexibilidade para um produto que pode mudar constantemente e de maneira veloz, como podemos perceber já que existe expectativa de crescimento tão grande tanto na equipe quanto na base de usuários que tende a ser multinacional. Com essa arquitetura, a Lei de Conway pode ser facilmente observada ao atribuir pequenos times para cuidar de cada sistema e dar um suporte contínuo e de alta qualidade em cada ponto. Além disso, a possibilidade de utilizar o canary deployment e de realizar implantação em cada microsserviço de forma separada corrobora com a necessidade de manter a solução online 24h. Em suma, todos os requisitos não funcionais guiaram essa decisão.

Em contrapartida, existe uma complexidade grande envolvida nesse tipo de solução que pode ser um risco quando mal aplicada, por isso é crucial o bom planejamento em cada decisão. Explicamos a partir daqui como fizemos o processo de descoberta de cada microsserviço, quais padrões foram escolhidos e por que escolhemos cada um.

### Visão arquitetural da solução

texto....

![Arquitetura Global](imagens/microservices-and-eda-view-pingr-0.png)

### Padrões de microsserviços adotados

* [CQRS - Command Query Responsibility Segregation](docs/patterns/cqrs.md)
* [Asynchronous message](docs/patterns/async-message.md)
* [EDA - Event Driven Architecture](docs/patterns/eda.md)
* [BFF - Backends For Frontends](docs/patterns/bff.md)

### Implementação

texto...

### Conclusão

texto...
