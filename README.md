Tarefas API

Descrição

Este é um projeto de API para gerenciamento de tarefas. A API permite criar, listar, atualizar e excluir tarefas, fornecendo um sistema simples para organização de atividades.

Tecnologias Utilizadas

Linguagem: Python

Framework: FastAPI

Banco de Dados: SQLite

Gerenciamento de Dependências: Poetry

Instalação

# Clone este repositório
git clone https://github.com/Bianca-Ribeiro-0/Tarefas-API.git

# Acesse o diretório do projeto
cd Tarefas-API

# Instale as dependências com Poetry
poetry install

Como Executar

# Ative o ambiente virtual do Poetry
poetry shell

# Execute a API
uvicorn main:app --reload

Acesse a documentação interativa da API no navegador:
http://127.0.0.1:8000/docs

Endpoints Principais

GET /tarefas - Retorna a lista de tarefas

POST /tarefas - Cria uma nova tarefa

PUT /tarefas/{id} - Atualiza uma tarefa existente

DELETE /tarefas/{id} - Remove uma tarefa

Contribuição

# Fork o repositório
git checkout -b minha-feature

# Commit suas mudanças
git commit -m 'Adicionando nova feature'

# Faça push para o repositório
git push origin minha-feature

Abra um Pull Request.

Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.
