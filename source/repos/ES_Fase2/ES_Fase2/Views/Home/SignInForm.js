import React from 'react';
import Button from 'react-bootstrap/Button';

function SignInForm() {
    return (
        <div class='signinform'>
            <form>
                <h1>Criar uma conta</h1>
                <br></br>
                <div class="form-group">
                    <input type="username" class="form-control" id="username" placeholder="Username"></input>
                </div>
                <br></br>
                <div class="form-group">
                    <input type="email" class="form-control" id="email" placeholder="E-mail"></input>
                </div>
                <br></br>
                <div class="form-group">
                    <input type="email" class="form-control" id="verifyemail" placeholder="Verify E-mail"></input>
                </div>
                <br></br>
                <div class="form-group">
                    <input type="password" class="form-control" id="pass" placeholder="Password"></input>
                </div>
                <br></br>
                <div class="form-group">
                    <input type="password" class="form-control" id="verifypass" placeholder="Verify Password"></input>
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