# AwesomeShop.Services.Customers - Formação Microsserviços com ASP.NET Core

A arquitetura do AwesomeShop, sistema de e-commerce baseado na arquitetura de microsserviços, contém 6 microsserviços:
- [Customers](https://github.com/fillipe-felix/AwesomeShop.Services.Customers)
- [Products](https://github.com/fillipe-felix/AwesomeShop.Services.Products) 
- [Orders](https://github.com/fillipe-felix/AwesomeShop.Services.Orders)
- [Payments](https://github.com/fillipe-felix/AwesomeShop.Services.Payments)
- [Notifications](https://github.com/fillipe-felix/AwesomeShop.Services.Notifications)
- [API Gateway](https://github.com/fillipe-felix/AwesomeShop.Services.ApiGateway)

## Tecnologias, práticas e arquitetura utilizadas
- ASP.NET Core com .NET 5
- Arquitetura de Microsserviços
- Princípios do Domain-Driven Design
- MongoDB
- Clean Architecture
- CQRS
- RabbitMQ e arquitetura orientada a eventos
- API Gateway com Ocelot 
- Service Discovery com Consul
- Observabilidade com Prometheus e Grafana

## Funcionalidades do Orders
- Cadastro
- Busca por Id
- Atualização de Status consumindo evento PaymentAccepted
