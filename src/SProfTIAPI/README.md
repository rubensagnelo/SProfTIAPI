# SProfTIAPI - Seletor de Profissinais de TI API
# ASP.NET Core 3.1 Server

Para deploy/execução da Aplicação seguir os seguites paços.

>> Execução da solução a aprtir de um ambiente para desenvolvimento
- Clonar a solução do GitHub ou extrair o zip recebido.
- Abrir solução no VS Code. Deverá ser aberta na pasta "raiz" onde foi extraida a solução clonada
- Executar a aplcação .Net core pressionando F5.

>> Executar a Aplicação a pelo prompt de comando
- Clonar a solução do GitHub ou extrair o zip recebido.
- Abrir solução no VS Code. Deverá ser aberta na pasta "raiz" onde foi extraida a solução clonada
- Executar o arquivo buildandRun.bat ou os seguintes comandos a partir da pasta SprofTIAPI\src\SProfTIAPI
dotnet clean  
dotnet restore  
dotnet build 
cd src\SProfTIAPI
dotnet run

Para executar as APIS com "notations" [Authorize] (inseridas apenas nas APIS que realizam alterção no Banco de dados) deve-se executar a API de autenticação jwt especificada no link do github https://github.com/rubensagnelo/SprofTI.Aut 

A lista de apis estão documentadas no endereço https://app.swaggerhub.com/apis/rubensagnelo/sprotiapi/1.0.2

Obs:O tempo de expiração está valido para 120 seg após a geração do token jwt. 
Para utilização das chamadas de api a partir do postman o token gerado deve ser postado no campo token após selecionar a aba Autorization e valorar o campo Type para "Bearer Token"

>> Geração do deploy
- Executar o arquivo dep.bat no prompt ou os seguintes comandos, a partir da pasta SprofTIAPI\src\SProfTIAPI :
    dotnet clean  
    dotnet restore 
    dotnet build 
    cd src
    dotnet publish -c Release -o out

    - Para executar a aplicação do deploy executar, na pasta src\SProfTIAPI\out (ou onde será copiado o conteudo dessa pasta) deve-se executar o seguinte comando no prompt: 
    dotnet SprofTI.Aut

