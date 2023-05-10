import React from 'react';
import Button from 'react-bootstrap/Button';

function SignInForm() {
    return (
        <div class='loginform'>
            <form>
                <h1>Login</h1>
                <br></br>
                <div class="form-group">
                    <input type="email" class="form-control" id="email" placeholder="E-mail"></input>
                </div>
                <br></br>
                <div class="form-group">
                    <input type="password" class="form-control" id="pass" placeholder="Password"></input>
                </div>
                <br></br>
                <div class="text-right">
                    <Button type='submit' variant="success"> Submit</Button>
                </div>
            </form>
        </div>
    )
}

export default SignInForm;