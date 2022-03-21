![](https://i.ibb.co/gdWN7Gv/Karate-Scenario-Generator.png)

# Karate Scenario Generator From Postman Collection

A fundamental application for generating Karate scenarios in Gherkin by using requests that in Postman Collection.
> Written by Emre Yavuz  | github.com/emreyvz

<br>

**Scenario Types**

- Happy Paths
- Null body field scenarios
- Missing body field scenarios (expected HTTP.400)
- Missing params scenarios (expected HTTP.400)
- Scenarios with missing Authorization field if auth field exist (expected HTTP.401)
- Wrong request method scenarios (expected HTTP.405)
- Scenarios with invalid data type of body fields. (Eg: "quantity": 5 -> "quantity": "5")
- Scenarios with invalid email address if email field exist in body (Eg: "email" : "this@wontwork" )
- Scenarios that checks every endpoint's response time is less than 100 ms

<br>

**Split Options**
- Create new feature file for different endpoints
- Create new feature file for same type of scenario
- Do not create extra feature file (use only 1 feature file)

<br>

**How to use**
- Drag & Drop or choose postman colletion to import
- Choose scenario types and split option
- Click 'Generate'

<br>

## License

<img src="https://opensource.org/files/osi_keyhole_300X300_90ppi_0.png" height="24" width="24">

- **[Apache 2.0 License](https://www.apache.org/licenses/LICENSE-2.0)**
- 2022 © Emre Yavuz
