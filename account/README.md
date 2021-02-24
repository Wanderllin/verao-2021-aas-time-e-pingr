### Account

Permite a gestão da conta dos usuários, permitindo o ajuste da visibilidade de perfil 
(público e privado) e a visibilidade padrão dos pings publicados;
Permite a criação listas de amigos especiais com usuários específicos;
Permite armazenar as configurações de exibição de mesas secundárias e de usuários seguidos pela conta de usuário;

Escopo da implementação 

Quando um usuario começa a seguir outro, uma notificação é gerada para seguido,
neste processo o serviço account recebe a notificação de "NewFollower" e faz a 
indexação entre os dois usuarios, gerando ao fnal uma mensagem representara por um 
arquivo JSON e direcionado para o canal "profile-interactions", que por sua vez se 
encarregua de informar ao usuario seu novo seguidor. 

LIST ACCOUNT:
http://localhost:8090/ime-rest/rest/service/list

ID: 
http://localhost:8090/ime-rest/rest/service/id/get/1
http://localhost:8090/ime-rest/rest/service/id/get/2
http://localhost:8090/ime-rest/rest/service/id/get/3
http://localhost:8090/ime-rest/rest/service/id/get/4
http://localhost:8090/ime-rest/rest/service/id/get/5
http://localhost:8090/ime-rest/rest/service/id/get/6

USER: 
http://localhost:8090/ime-rest/rest/service/user/get/DCD
http://localhost:8090/ime-rest/rest/service/user/get/VDLN
http://localhost:8090/ime-rest/rest/service/user/get/RF
http://localhost:8090/ime-rest/rest/service/user/get/VC
http://localhost:8090/ime-rest/rest/service/user/get/GUILH
http://localhost:8090/ime-rest/rest/service/user/get/MR

NEW FOLLOW: 
http://localhost:8090/ime-rest/rest/service/followdestination/get/VDLN
http://localhost:8090/ime-rest/rest/service/followdestination/get/RF
http://localhost:8090/ime-rest/rest/service/followdestination/get/VC
http://localhost:8090/ime-rest/rest/service/followdestination/get/GUILH
http://localhost:8090/ime-rest/rest/service/followdestination/get/MR