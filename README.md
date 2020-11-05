# webapi
Api de contracheque para exibição de salário liquido e descontos do funcionário. <Br/>
O projeto cria um ambiente com a api e banco de dados postgresql através da ferramenta Docker.

# requisitos
<a href="https://www.docker.com/get-started"> Docker </a>

# endpoints

<b>Get:</b> <br/>
parâmetros: <br/>
id do funcionário <br/>
<b>/employees/{id}</b>: retorna as informações do funcionário com o {id} informado. <br/>

<b>Get:</b> <br/>
parâmetros: <br/>
id do funcionário <br/>
<b>/employees/paycheck/{id}</b>: retorna o extrato salarial do funcionário com o {id} informado. <br/>

<b>Post:</b><br/>
<b>/employees/{id}</b>: permite inserir funcionário no sistema.
