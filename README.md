
# ExtracttaTest - Seguros Automotivos

Este projeto consiste em uma **API .NET 9**, um **frontend Angular** e um **SQL Server**, todos orquestrados via **Docker Compose**.

---

## 🔧 Como executar o projeto

1. Certifique-se de estar na **raiz do projeto** (onde está o `docker-compose.yml`).
2. Execute o seguinte comando para iniciar os containers:

```bash
docker-compose up --build
```

---

## 🌐 Endpoints e Portas

| Serviço       | URL                                        | Porta     |
|---------------|---------------------------------------------|-----------|
| API (HTTP)    | http://localhost:5000                      | `5000`    |
| API (HTTPS)   | https://localhost:5001                     | `5001`    |
| Frontend      | http://localhost:5009                      | `5009`    |
| SQL Server    | localhost:14333                            | `14333`   |

---

## 📦 Rotas da API

### 🔹 SeguradoController (`/segurado`)

| Método | Rota                | Descrição                      |
|--------|---------------------|-------------------------------|
| GET    | `/segurado`         | Lista todos os segurados      |
| GET    | `/segurado/{id}`    | Busca segurado por ID         |
| POST   | `/segurado`         | Cria um novo segurado         |

---

### 🔹 SeguroController (`/seguro`)

| Método | Rota                              | Descrição                                  |
|--------|-----------------------------------|---------------------------------------------|
| GET    | `/seguro`                         | Lista todos os seguros                     |
| GET    | `/seguro/{id}`                    | Busca seguro por ID                        |
| POST   | `/seguro`                         | Cria um novo seguro                        |
| GET    | `/seguro/mediaAritmetica`         | Calcula média geral                        |
| GET    | `/seguro/mediaAritmetica?filter=segurado` | Média por segurado                 |
| GET    | `/seguro/mediaAritmetica?filter=veiculo`  | Média por veículo                   |

---

### 🔹 VeiculoController (`/veiculo`)

| Método | Rota                           | Descrição                              |
|--------|--------------------------------|-----------------------------------------|
| GET    | `/veiculo`                     | Lista todos os veículos                |
| GET    | `/veiculo/{id}`                | Busca veículo por ID                   |
| POST   | `/veiculo`                     | Cria um novo veículo                   |
| POST   | `/veiculo/calculaSeguro`       | Calcula o valor do seguro do veículo  |

---

## 🛠️ Requisitos

- Docker e Docker Compose instalados.
- Porta `5000`, `5001`, `5009` e `14333` liberadas.

---

## 📁 Estrutura dos Projetos

```plaintext
/
├── docker-compose.yml
├── ExtracttaTest.WebApi/         # Projeto da API
├── ExtracttaTest.Presentation/   # Projeto Angular
├── ExtracttaTest.Application/    # Camada de aplicação
├── ExtracttaTest.Domain/         # Camada de domínio
├── ExtracttaTest.Infrastructure/ # Camada de infraestrutura
```

---

## 💡 Observações

- O CORS está habilitado na WebApi para permitir o consumo pelo Angular.
- A API utiliza `IMediator` para aplicar o padrão CQRS com `MediatR`.

---

## 🖼️ Dashboard

O frontend Angular exibe:
- A **média geral** dos valores dos seguros.
- A **lista de médias** agrupadas por **segurado**.
- A **lista de médias** agrupadas por **veículo**.

---
