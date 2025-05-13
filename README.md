# 📦 **Exemplo API com relacionamento entre tabelas (1:N)**

API desenvolvida em **ASP.NET Core 8** com **Entity Framework Core** e **Oracle** para gerenciar **Produtos** e **Fornecedores**.

---

## 🛠️ **Tecnologias Utilizadas**

- **ASP.NET Core 8**
- **Entity Framework Core**
- **Banco de Dados Oracle**
- **AutoMapper**
- **Swagger (Swashbuckle)**
- **Data Annotations** (validações)

---

## 🔗 **Relacionamento entre Entidades**

- Um **Fornecedor** pode ter **vários Produtos** (_1:N_).
- Cada **Produto** pertence a **um único Fornecedor**.

---

## 💡 **Conceitos Aplicados**
- Separação de responsabilidades com uso de DTOs
- Validação com Data Annotations
- Mapeamento entre entidades com AutoMapper
- Uso de Lazy Loading / Eager Loading com Include()
- Desacoplamento de modelos de entrada e saída
