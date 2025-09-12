# Desafio Tecnico Micro Serviços Aanade DIO

## Entendendo Desafio Técnico - Microserviços
### Descrição do Desafio
Desenvolver uma aplicação com arquitetura de microserviços para gerenciamento de estoque de produtos e vendas em uma plataforma de e-commerce. O sistema será composto por dois microserviços: um para gerenciar o estoque de produtos e outro para gerenciar as vendas, com comunicação entre os serviços via API Gateway. 

<b>Tecnologias:</b> .NET Core, C#, Entity Framework, RESTful API, RabbitMQ (para comunicação entre microserviços), JWT (para autenticação) e banco de dados relacional. 


### Arquitetura Proposta 
<ul>
    <li>
        <b>Microserviço 1 (Gestão de Estoque):</b> 
        Responsável por cadastrar produtos, controlar o estoque e fornecer informações sobre a quantidade disponível. 
    </li>
    <li>
        <b>Microserviço 2 (Gestão de Vendas):</b> 
        Responsável por gerenciar os pedidos e interagir com o serviço de estoque para verificar a disponibilidade de produtos ao realizar uma venda. 
    </li>
    <li>
        <b>API Gateway:</b> 
        Roteamento das requisições para os microserviços adequados. Este serviço atua como o ponto de entrada para todas as chamadas de API. 
    </li>
    <li>
        <b>RabbitMQ:</b> 
        Usado para comunicação assíncrona entre os microserviços, como notificações de vendas que impactam o estoque. 
    </li>
    <li>
        <b>Autenticação com JWT:</b> 
        Garantir que somente usuários autenticados possam realizar ações de vendas ou consultar o estoque.
    </li>
</ul>

### Funcionalidades Requeridas

#### Microserviço 1 (Gestão de Estoque): 
<ul>
    <li>
        <b>Cadastro de Produtos:</b> Adicionar novos produtos com nome, descrição, preço e quantidade em estoque. 
    </li>
    <li>
        Consulta de Produtos: Permitir que o usuário consulte o catálogo de produtos e a quantidade disponível em estoque. 
    </li>
    <li>
        Atualização de Estoque: O estoque deve ser atualizado quando ocorrer uma venda (integração com o Microserviço de Vendas). 
    </li>
</ul>


####  Microserviço 2 (Gestão de Vendas): 
<ul>
    <li>
    Criação de Pedidos: Permitir que o cliente faça um pedido de venda, com a validação do estoque antes de confirmar a compra. 
    </li>
    <li>
    Consulta de Pedidos: Permitir que o usuário consulte o status dos pedidos realizados. 
    </li>
    <li>
    Notificação de Venda: Quando um pedido for confirmado, o serviço de vendas deve notificar o serviço de estoque sobre a redução do estoque. 
    </li>
</ul>


#### Comum aos dois microserviços: 
<ul>
    <li>
        Autenticação via JWT: Apenas usuários autenticados podem interagir com os sistemas de vendas ou consultar o estoque. 
    </li>
    <li>
        API Gateway: Usar um gateway para centralizar o acesso à API, garantindo que as requisições sejam direcionadas ao microserviço correto
    </li>
</ul>


### Contexto do Negócio
<p>A aplicação simula um sistema para uma plataforma de e-commerce, onde empresas precisam gerenciar seu estoque de produtos e realizar vendas de forma eficiente. A solução deve ser escalável e robusta, com separação clara entre as responsabilidades de estoque e vendas, utilizando boas práticas de arquitetura de microserviços. Esse tipo de sistema é comum em empresas que buscam flexibilidade e alta disponibilidade em ambientes com grande volume de transações. </p>

### Requisitos Técnicos
<ul>
    <li>
        Tecnologia: .NET Core (C#) para construir as APIs. 
    </li>
    <li>
        Banco de Dados: Usar Entity Framework com banco de dados relacional (SQL Server ou outro).
    </li> 
    <li>
        Microserviços: 
        <ul>
            <li>
                Microserviço de Gestão de Estoque deve permitir cadastrar produtos, consultar estoque e atualizar quantidades. 
            </li>
            <li>
                Microserviço de Gestão de Vendas deve validar a disponibilidade de produtos, criar pedidos e reduzir o estoque. 
            </li>
            <li>
                Comunicação entre Microserviços: Usar RabbitMQ para comunicação assíncrona entre os microserviços, especialmente para notificar mudanças de estoque após uma venda.
            </li>
        </ul>
    </li>
    <li>
        Autenticação: Implementar autenticação via JWT para proteger os endpoints e garantir que apenas usuários autorizados possam realizar ações. 
    </li>
    <li>
        API Gateway: Usar um API Gateway para redirecionar as requisições de clientes para os microserviços corretos. 
    </li>
    <li>
        Boas Práticas: Seguir boas práticas de design de API, como a utilização de RESTful APIs, tratamento adequado de exceções e validações de entrada. 
    </li>
</ul>

### Critérios de Aceitação
<ul>
    <li>
        O sistema deve permitir o cadastro de produtos no microserviço de estoque. 
    </li>
    <li>
        O sistema deve permitir a criação de pedidos no microserviço de vendas, com validação de estoque antes de confirmar o pedido. 
    </li>
    <li>
        A comunicação entre os microserviços deve ser feita de forma eficiente usando RabbitMQ para notificações de vendas e atualizações de estoque. 
    </li>
    <li>
        O sistema deve ter uma API Gateway que direcione as requisições para os microserviços corretos. 
    </li>
    <li>
        O sistema deve ser seguro, com autenticação via JWT para usuários e permissões específicas para cada ação. 
    </li>
    <li>
        O código deve ser bem estruturado, com separação de responsabilidades e boas práticas de POO. 
    </li>
</ul>

### Extras
Testes Unitários: Criar testes unitários para as funcionalidades principais, como cadastro de produtos e criação de pedidos. 

Monitoramento e Logs: Implementar monitoramento básico de logs para rastrear falhas e transações no sistema. 

Escalabilidade: O sistema deve ser capaz de escalar facilmente, caso seja necessário adicionar mais microserviços (ex: microserviço de pagamento ou de envio). 

## Rresolução

Para a resolução desse desafio, inicialmente consultei a documentação de outro projeto, desenvolvido com Minimal Api em .NET, também da DIO. Embora a versão utilizada no projeto seja anterior, e o padrão de arquitetura usado no projeto seja diferente. Como nunca tinha tentado criar um projeto com micro serviços, esse modelo serviu como base para a criação dos serviços.

Como é minh primeira aplicção com micro serviços, realisei pesquisas em artigos indicados no forum e em outros canais, como na FreeCodeCamp e na documentação da Microsoft. Alem disso discuti abordagens, estrutura de pastas e questões de segurança com IAs generativas. Como Gemini e Chat GPT. Com isso decidi que uma abordagem interessante para iniciar seria criando primeiro as entidades, começando com os diagramas dos bancos de dados. 

### Passos Realizados

Criação da Solution
Criação ds pastas dos servicos
Divisão dos serviços em 3 projetos(libs de classes): Domain, API e Infra

Serviço



