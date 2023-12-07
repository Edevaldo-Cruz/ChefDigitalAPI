# Chef Digital API


### Descrição

Esta API foi desenvolvida para atender às necessidades do front-end de uma lanchonete, adotando uma abordagem simplificada de interação que não requer login por parte do usuário. Importante notar que todas as informações de nome dos produtos e preços são fornecidas diretamente do front-end, seguindo as regras de negócio estabelecidas. Mesmo com dados mínimos fornecidos pelo usuário, a API é capaz de identificar o cliente, registrar seus pedidos e oferecer vantagens de fidelidade. Esse sistema proporciona uma experiência de usuário simplificada e mantém um alto nível de personalização, garantindo recompensas e benefícios para os clientes fiéis. Essa abordagem não apenas simplifica a jornada do cliente, mas também estimula a lealdade, tornando cada interação com a lanchonete mais gratificante e personalizada.


### Forma de Uso
A API oferece diversas funcionalidades para interação com o sistema de pedidos da lanchonete. Abaixo estão alguns exemplos de uso das principais rotas:

## Order

### Registrar um Novo Pedido

```csharp
POST /api/Order
```

#### Create
 
Este endpoint POST permite a criação de um novo pedido. Ao receber uma requisição com os detalhes do pedido em formato JSON no corpo da solicitação, ele aciona o serviço correspondente para criar o pedido na plataforma. O endpoint verifica se o pedido foi processado com sucesso:

* **Método: POST**
* **Parâmetros:** Um objeto **OrderCreateDTO** contendo os detalhes do pedido.

* **Retorno**:

	* **404 Not Found** se o cliente associado ao pedido não for encontrado.
	* **400 Bad Request** se houver problemas identificados no pedido.
	* **200 OK** se o pedido for concluído com êxito.

**Exemplo de uso:**

```json

{
  "clientId": "88019B39-7024-4C3C-87A1-059D3AD39C91",
  "orderedItems": [
    {
      "item": "Sanduiche Natural",
      "unitValue": 7,
      "itemQuantity": 3
    },
	{
      "item": "Fanta laranja Lt",
      "unitValue": 4,
      "itemQuantity": 3
    }
  ]
}

```


**Exemplo de resposta:**

```http
HTTP/1.1 200 OK
Content-Type: application/json

"Pedido realizado com sucesso."

```

### Registrar um Novo Pedido e Um Novo Cliente


```csharp
POST /api/Order/CreateOrderNewClient
```

#### CreateOrderNewClient

Este endpoint POST permite a criação de um novo pedido para um cliente não cadastrado, realizando também o cadastro do cliente. Ao receber uma requisição com os detalhes do pedido em formato JSON no corpo da solicitação, ele ativa o serviço correspondente para criar tanto o cliente quanto o pedido na plataforma. A função verifica se o pedido foi processado com sucesso e retorna uma mensagem indicativa do resultado:

* **Método: POST**

* **Parâmetros:** Um objeto **OrderCreateNewClientDTO** contendo os detalhes do pedido.

* **Retorno:**
	* **400 Bad Request** se ocorrer um erro durante o processamento do pedido ou se 		houver problemas identificados no pedido.
	* **200 OK** se o pedido for concluído com êxito.

**Exemplo de uso:**


```json

{
  "firstName": "João",
  "surname": "Silva",
  "telephone": "+55123456789",
  "email": "joao.silva@example.com",
  "street": "Rua das Flores",
  "number": 123,
  "neighborhood": "Centro",
  "city": "São Paulo",
  "zipCode": "01234-567",
  "orderedItems": [
    {
      "item": "Hambúrguer",
      "unitValue": 10.99,
      "itemQuantity": 2
    },
    {
      "item": "Batata frita",
      "unitValue": 5.5,
      "itemQuantity": 1
    }
  ]
}


```


**Resposta de Exemplo:**

```http
HTTP/1.1 200 OK
Content-Type: application/json

"Pedido realizado com sucesso."

```


### Cancelar Pedido


```csharp
PUT /api/Order/CancelOrder/{id}
```

#### CancelOrder

Este endpoint PUT permite o cancelamento de um pedido existente por meio de sua identificação única (ID). Ao receber uma requisição para cancelar um pedido específico, utilizando o ID como parâmetro na URL, ele ativa o serviço correspondente para realizar o cancelamento na plataforma. 

* **Método: PUT**

* **Parâmetros:** O ID do pedido a ser cancelado.

* **Retorno:**
	* **400 Bad Request** se houver problemas identificados no processo de 				cancelamento.
	* **200 OK** se o pedido for cancelado com êxito.

**Exemplo de uso:**


```http
PUT /cancel-order/12345678-90ab-cdef-1234-567890abcdef

```


**Resposta de Exemplo:**

```http
HTTP/1.1 200 OK
Content-Type: application/json

"Pedido cancelado."

```


### Atualização de Status do Pedido


```csharp
PUT /api/Order/UpdateStatusOrder/{id}
```

#### UpdateStatusOrder

Este endpoint PUT permite a atualização do status de um pedido específico, identificado por meio de um ID único passado como parâmetro na URL. Ao receber uma requisição para atualizar o status desse pedido, o endpoint ativa o serviço correspondente para efetuar a mudança de status na plataforma.

* **Método: PUT**

* **Parâmetros:** O ID do pedido para o qual se deseja atualizar o status.

* **Retorno:**
	* **400 Bad Request** em caso de problemas identificados durante a atualização do status.
	* **200 OK** quando o status do pedido é atualizado com sucesso.

**Exemplo de uso:**


```http
PUT /UpdateStatusOrder/12345678-90ab-cdef-1234-567890abcdef

```


**Exemplo de resposta:**

```http
HTTP/1.1 200 OK
Content-Type: application/json

"Status do pedido atualizado."

```

## Client

### Registrar um Novo Cliente

```csharp
POST /api/Client
```

#### Create
 
Este endpoint POST permite a criação de um novo cliente. Ao receber uma requisição com os detalhes do cliente em formato JSON no corpo da solicitação, o endpoint aciona o serviço correspondente para criar um novo cliente na plataforma

* **Método: POST**
* **Parâmetros:** Um objeto ClientCreateDTO contendo os detalhes do novo cliente.

* **Retorno**:

	* **400 Bad Request** em caso de problemas identificados durante a criação do cliente.
	* **200 OK**  quando o cliente é criado com sucesso, retornando os detalhes do novo cliente criado.

**Exemplo de uso:**

```json
{
  "firstName": "Ana",
  "surname": "Silva",
  "telephone": "+551234567890",
  "email": "ana.silva@example.com",
  "street": "Rua das Flores",
  "number": 123,
  "neighborhood": "Centro",
  "city": "São Paulo",
  "zipCode": "01234-567"
}

```


**Exemplo de resposta:**

```json
HTTP/1.1 200 OK
Content-Type: application/json

{
  "firstName": "Ana",
  "surname": "Silva",
  "telephone": "+551234567890",
  "email": "ana.silva@example.com",
  "street": "Rua das Flores",
  "number": 123,
  "neighborhood": "Centro",
  "city": "São Paulo",
  "zipCode": "01234-567"
}
```

### Editar Cliente

```csharp
PUT /api/Client
```

#### Edit
 
Este endpoint PUT permite a edição de um cliente existente através do seu ID único. Ao receber uma requisição para editar um cliente específico, utilizando o ID como parâmetro na URL e os novos detalhes do cliente em formato JSON no corpo da solicitação, o endpoint aciona o serviço correspondente para realizar a edição na plataforma. 

* **Método: PUT**
* **Parâmetros:**  O ID do cliente a ser editado (id) e um objeto ClientEditDTO contendo os novos detalhes do cliente.

* **Retorno**:

	* **400 Bad Request** em caso de problemas identificados durante a edição do cliente.
	* **200 OK**  quando o cliente é editado com sucesso, retornando os detalhes do cliente editado.

**Exemplo de uso:**

```json
{
  "firstName": "João",
  "surname": "Silva",
  "telephone": "+551234567890",
  "email": "joao.silva@example.com",
  "active": true
}
```


**Exemplo de resposta:**

```json
HTTP/1.1 200 OK
Content-Type: application/json

{
  "id": "12345678-90ab-cdef-1234-567890abcdef",
  "firstName": "João",
  "surname": "Silva",
  "telephone": "+551234567890",
  "email": "joao.silva@example.com",
  "active": true
}
```

### Listar Clientes

```csharp
GET /api/Client
```

#### List
 
Este endpoint GET permite listar todos os clientes cadastrados no sistema. Ao receber uma requisição, o endpoint aciona o serviço correspondente para obter uma lista de todos os clientes na plataforma e retorna essa lista como um objeto List<ClientListDTO>.


* **Método: GET**

* **Retorno**: Uma lista de clientes cadastrados.
	
**Exemplo de uso:**

```json
GET /
```


**Exemplo de resposta:**

```json
HTTP/1.1 200 OK
Content-Type: application/json

[
  {
    "id": "1a2b3c4d-5678-90ef-abcd-1234567890ef",
    "firstName": "João",
    "surname": "Silva",
    "email": "joao.silva@example.com",
    // Outros detalhes do cliente...
  },
  {
    "id": "5e6f7g8h-9012-34ij-klmn-567890abcd12",
    "firstName": "Maria",
    "surname": "Souza",
    "email": "maria.souza@example.com",
    // Outros detalhes do cliente...
  }
  // Outros clientes...
]
```

### Buscar Cliente por ID

```csharp
GET /api/Client
```

#### SearchCustomer
 
Este endpoint GET permite encontrar um cliente específico na plataforma utilizando o seu ID único como parâmetro na URL.


* **Método: GET**
* **Parâmetros:** O ID do cliente (id) que se deseja buscar.

* **Retorno:**
	* * **400 Bad Request** se o cliente não for encontrado na plataforma.
	* **200 OK** com os detalhes do cliente encontrado.
	
**Exemplo de uso:**

```json
GET /12345678-90ab-cdef-1234-567890abcdef
```


**Exemplo de resposta:**

```json
HTTP/1.1 200 OK
Content-Type: application/json

{
  "id": "12345678-90ab-cdef-1234-567890abcdef",
  "firstName": "João",
  "lastName": "Silva",
  "email": "joao.silva@example.com",
  // Outros detalhes do cliente...
}
```

### Desabilitar Cliente

```csharp
PUT /api/Client/disable/{id}
```

#### DisableClient
 
Este endpoint PUT permite desabilitar um cliente existente através do seu ID único. Ao receber uma requisição para desabilitar um cliente específico, utilizando o ID como parâmetro na URL, o endpoint aciona o serviço correspondente para realizar a ação de desabilitação na plataforma.


* **Método: PUT**
* **Parâmetros:** O ID do cliente a ser desabilitado (id).
* 
* **Retorno**:
	* * **400 Bad Request** em caso de problemas identificados durante a operação de 		desabilitação do cliente.
	* **200 OK** quando o cliente é desabilitado com sucesso.
	
**Exemplo de uso:**

```json
PUT /disable/12345678-90ab-cdef-1234-567890abcdef
```


**Exemplo de resposta:**

```json
HTTP/1.1 200 OK
Content-Type: text/plain

"Cliente desabilitado."
```

## Address

### Registrar um Novo Endereço

```csharp
POST /api/Address
```

#### Create
 
Este endpoint POST permite a criação de um novo endereço para um cliente específico. Ao receber uma requisição com os detalhes do endereço em formato JSON no corpo da solicitação, o endpoint aciona o serviço correspondente para criar o endereço associado ao cliente identificado pelo clientId.

* **Método: POST**
* **Parâmetros:** O ID do cliente (clientId) e um objeto AddressCreateDTO com os detalhes do endereço.

* **Retorno**:

	* **400 Bad Request** em caso de problemas identificados durante a criação do endereço.
	* **200 OK** quando o endereço é criado com sucesso, retornando os detalhes do endereço criado.

**Exemplo de uso:**

```json
{
  "street": "Avenida Paulista",
  "number": 1000,
  "neighborhood": "Bela Vista",
  "city": "São Paulo",
  "zipCode": "01310-100"
}
```


**Exemplo de resposta:**

```http
HTTP/1.1 200 OK
Content-Type: application/json

{
  "id": "98765432-fedc-ba98-7654-3210fedcba09",
  "street": "Rua das Flores",
  "number": 123,
  "city": "São Paulo",
  "zipCode": "01234-567",
  "clientId": "12345678-90ab-cdef-1234-567890abcdef"
}
```

### Editar Endereço

```csharp
PUT /api/Address/{id}
```

#### Edit
 
Este endpoint PUT permite editar um endereço existente por meio do seu ID único. Ao receber uma requisição para editar um endereço específico, utilizando o ID como parâmetro na URL e os novos detalhes do endereço em formato JSON no corpo da solicitação, o endpoint aciona o serviço correspondente para realizar a edição na plataforma.

* **Método: PUT**
* **Parâmetros:** O ID do endereço a ser editado (id) e um objeto AddressEditDTO contendo os novos detalhes do endereço.

* **Retorno**:

	* **400 Bad Request** em caso de problemas identificados durante a edição do endereço.
	* **200 OK** quando o endereço é editado com sucesso, retornando os detalhes do endereço editado.

**Exemplo de uso:**

```json
{
  "clientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "street": "Avenida Paulista",
  "number": 1000,
  "neighborhood": "Bela Vista",
  "city": "São Paulo",
  "zipCode": "01310-100"
}
```


**Exemplo de resposta:**

```http
HTTP/1.1 200 OK
Content-Type: application/json

{
  "id": "12345678-90ab-cdef-1234-567890abcdef",
  "street": "Nova Rua",
  "number": 456,
  "neighborhood": "Novo Bairro",
  "city": "Nova Cidade",
  "zipCode": "98765-432"
}
```

### Listar Endereços

```csharp
GET /api/Address/
```

#### List
 
Este endpoint GET permite listar todos os endereços cadastrados no sistema. Ao receber uma requisição, o endpoint aciona o serviço correspondente para obter uma lista de endereços existentes na plataforma e retorna esses endereços em um array JSON:

* **Método: GET**

* **Retorno**:

	* **200 OK** uma lista de endereços cadastrados.

**Exemplo de uso:**

```http
GET /
```


**Exemplo de resposta:**

```http
HTTP/1.1 200 OK
Content-Type: application/json

[
  {
    "id": "12345678-90ab-cdef-1234-567890abcdef",
    "street": "Avenida Paulista",
    "number": 1000,
    "neighborhood": "Bela Vista",
    "city": "São Paulo",
    "zipCode": "01310-100"
  },
  {
    "id": "98765432-fedc-ba98-7654-3210fedcba09",
    "street": "Rua Nova",
    "number": 200,
    "neighborhood": "Centro",
    "city": "Rio de Janeiro",
    "zipCode": "20000-000"
  }
  // Mais endereços...
]

```

### Listar Endereços por ID do Cliente
```csharp
GET /api/Address/{id}
```

#### ListByIdClient
 
Este endpoint GET permite listar os endereços associados a um cliente específico através do seu ID. Ao receber uma requisição com o ID do cliente como parâmetro na URL, o endpoint aciona o serviço correspondente para obter a lista de endereços vinculados ao cliente na plataforma e retorna esses endereços em um array JSON:

* **Método: GET**
* **Parâmetros:**  O ID do cliente (idCliente) para o qual se deseja listar os endereços.

* **Retorno**:

	* **400 Bad Request** se não forem encontrados endereços associados ao cliente.
	* **200 OK** com uma lista dos endereços vinculados ao cliente.

**Exemplo de uso:**

```
GET /12345678-90ab-cdef-1234-567890abcdef
```


**Exemplo de resposta:**

```http
HTTP/1.1 200 OK
Content-Type: application/json

[
  {
    "id": "1a2b3c4d-5678-90ef-abcd-1234567890ef",
    "street": "Rua das Flores",
    "number": 123,
    "neighborhood": "Centro",
    "city": "São Paulo",
    "zipCode": "01234-567"
  },
  {
    "id": "5e6f7g8h-9012-34ij-klmn-567890abcd12",
    "street": "Avenida Central",
    "number": 456,
    "neighborhood": "Bairro Novo",
    "city": "Rio de Janeiro",
    "zipCode": "12345-678"
  }
  // Mais endereços associados ao cliente...
]
```
### Desabilitar Endereço por ID

```csharp
PUT /api/Address/disable/{id}
```

#### DisableAddress
 
Este endpoint PUT permite desabilitar um endereço existente através do seu ID único. Ao receber uma requisição para desabilitar um endereço específico, utilizando o ID como parâmetro na URL, o endpoint aciona o serviço correspondente para realizar a desabilitação na plataforma.

* **Método: PUT**
* **Parâmetros:** OO ID do endereço a ser desabilitado (id).

* **Retorno**:

	* **400 Bad Request** em caso de problemas identificados durante a desabilitação do endereço.
	* **200 OK** quando o endereço é desabilitado com sucesso, retornando os detalhes do endereço desabilitado.

**Exemplo de uso:**

```json
PUT /disable/12345678-90ab-cdef-1234-567890abcdef
```


**Exemplo de resposta:**

```http
HTTP/1.1 200 OK
Content-Type: application/json

{
  "id": "12345678-90ab-cdef-1234-567890abcdef",
  "disabled": true
}
```
