# verao-2021-aas-time-e-pingr
Projeto Pingr - Arquitetura Ágil de Software - EaD - 18/01/2021 a 26/02/2021

## Como subir a infraestrutura

Basta instalar o Docker e depois digitar na linha de comando de um shell:

`docker-compose up -d`


## Justificativas para o uso de CQRS:

•	Dimensionamento independente. O CQRS permite que as cargas de trabalho de leitura e gravação sejam dimensionadas de forma independente e pode resultar em menos contenções de bloqueio.

•	Esquemas de dados otimizados. O lado de leitura pode usar um esquema que é otimizado para consultas, enquanto o lado de gravação usa um esquema que é otimizado para atualizações.

•	Segurança. É mais fácil garantir que apenas as entidades do direito de domínio estejam executando gravações nos dados.

•	Separação de preocupações. Isolar os lados de leitura e gravação pode resultar em modelos mais flexíveis e sustentáveis. A maior parte da lógica de negócios complexa vai para o modelo de gravação. O modelo de leitura pode ser relativamente simples.

•	Consultas mais simples. Ao armazenar uma exibição materializada no banco de dados de leitura, o aplicativo poderá evitar junções complexas durante as consultas.


