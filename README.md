# WebApi
API de contracheque para exibição de salário liquido e descontos do funcionário.
O projeto cria um ambiente com a API e banco de dados PostgreSQL através da ferramenta Docker.

# Autenticação
Não é preciso utilizar autenticação para fazer requisições a esta API.

# Requisitos
<a href="https://www.docker.com/get-started"> Docker </a>

# Error Codes

**400 – Bad Request**
Dados enviados de forma incorreta ou fora do padrão.

**404 – Not Found**
Nenhum dado foi encontrado com o parâmetro utilizado.

**409 – Conflict**
Dado enviado já existe na base de dados.

# Configuração
Para iniciar o projeto seguir os seguintes passos:

Faça o clone do projeto:
git clone https://github.com/pablosalipio/webapi.git

Crie a imagem no docker:
docker build -t webapi .

Inicie o projeto:
docker-compose up

# Swagger
O projeto possui o Swagger(http://localhost:8000/swagger/), onde podemos realizar as chamadas dos endpoints, para isso clique em "Try it out":
GETs: Informe o ID no campo e clique em Execute.
POST: Preencha o Request Body (possui um exemplo no quadro acima) e clique em Execute.

# Docker
<ul>
<li>
<a href="https://hub.docker.com/repository/docker/pabloalipio/postgres"> Imagem Postgres </a>
</li>
<li>
<a href="https://hub.docker.com/repository/docker/pabloalipio/webapi"> Imagem Webapi </a>
</li>
</ul>

# Postman
Para acessa a documentação disponível no Postman, <a href="https://documenter.getpostman.com/view/12743986/TVYQ3Eri">clique aqui</a>.
