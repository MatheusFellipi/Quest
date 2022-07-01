## Quest

##   História Post-it
 
  <p>
  Um usuário conta a seguinte história para ajudar você a desenvolver um software que simula post-its para ele:

  "Preciso de uma tela onde eu possa inserir um texto com o título de uma tarefa, outro texto com a descrição desta tarefa e uma data de prazo para realização desta tarefa. Preciso que os dados sejam armazenados em um banco de dados relacional. Inicialmente preciso somente que o software salve estas informações no banco de dados e novas funcionalidades serão mencionadas nos próximos sprints."
</p>

# Tecnologia

- ASP.Net core 3.1
- ORM Entity framework

# Hospetagem

A `API` esta hospedada na `AZURE` junto com o banco de dados.

# EndPoint

-  API https://quest20220630122010.azurewebsites.net

  - Cadastrar um usuário `/api/user`

    ```
      	Email: string, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
	Password: string, maior que 6 caractere 
	role: string
    ```
    
    ```
      //200

	id: int,
	Email: string,
	Password: string,
	role: string
    ```
  
  - Logar na api `/api/account/login`
    
    ```
	email: string,
	password: string,
    ```

    ```
      //200

      	user: user
	token: JTW bearer token
    ```

  - pegar todos os post do usuário `api/post/user/:id_user` `Header authorization`

   ```
     //200
   
   	 id: int,
	 title: string,
	 description: string,
   	 active: string,
	 id_User: 1,
   ```
