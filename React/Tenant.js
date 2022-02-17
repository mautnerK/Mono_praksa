import React, {Component} from "react";
import {Table, Button} from "reactstrap";
import axios from 'axios';
class Tenant extends Component{

    state = {
        tenants: []
    }

    componentWillMount(){
        axios.get('https://localhost:44315/api/Tenant').then((response)=>{
            this.setState({
                tenants: response.data
            })
        }); 
    }
    
    deleteTenant(id){
    axios.delete('https://localhost:44315/api/Tenant/'+id).then((response)=>{
        this.refreshTenants();
    })
}
refreshTenants(){
    axios.get('https://localhost:44315/api/Tenant').then((response)=>{
            this.setState({
                tenants: response.data
            })
        }); 
}
    render(){
        let tenants=this.state.tenants.map((tenant)=>{
            return(
                <tr >
                    <td>
                    {tenant.Id}
                    </td>
                    <td>
                    {tenant.Name}
                    </td>
                    <td>
                    {tenant.Surname}
                    </td>
                    <td>
                    {tenant.PhoneNumber}
                    </td>
                    <td>
                    {tenant.Email}
                    </td>
                    <td>
                    <Button color="success" size="sm" onClick={this.deleteTenant.bind(this,tenant.Id)}>Edit</Button>
                        <Button color="danger" size="sm" onClick={this.deleteTenant.bind(this,tenant.Id)}>Remove</Button>
                    </td>
                </tr>
            )
        });

        return(
            <div className="Tenant">
                <Table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Phone Number</th>
                        <th>Email</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                   {tenants}
                </tbody>
                </Table>
            </div>
        )
    }

}

export default Tenant;