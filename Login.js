import {   Button, Form, FormGroup, Input, Label} from 'reactstrap';
import { Component } from 'react';
import axios from 'axios';
import './Login.css';


class  Login extends Component{

    state = {
        landlords: []
    } 

    constructor(props) {
        super(props);
        this.state = {
          email: '',
          password: ''
        };
        this.handleChange = this.handleChange.bind(this);
      }

     
     handleChange = (event) => {
        const { target } = event;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const { name } = target;
      
        this.setState({
          [name]: value,
        });
      };

      buttonClick(){
        console.log("bravo");
      }
  
      
    render(){
        return (
            
            <div>
                <div>
                <h1>Booking</h1>
                
                </div>
                <div className="Login">
                
                <Form className="form">
                    <FormGroup>
                    <Label id="email" for="Email">Email</Label>
                    <Input
                        type="email"
                        name="email"
                        id="exampleEmail"
                        placeholder="example@example.com"
                    />
                    </FormGroup>
                    <FormGroup>
                    <Label id="pass" for="Password">Password</Label>
                    <Input
                        type="password"
                        name="password"
                        id="examplePassword"
                        placeholder="********"
                    />
                    </FormGroup>
                <Button onClick={this.buttonClick()}>Submit</Button>
                </Form>
            </div>
          </div>
        );
}
}
export default Login;