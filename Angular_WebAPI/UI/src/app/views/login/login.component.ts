import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router'

import { AuthenticationService } from '../../services/authentication.service'

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit {
  loginControls = this.fb.group({
    email: new FormControl('', [Validators.required, Validators.maxLength(100),
    Validators.pattern('[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}')]),
    password: ['', Validators.required],
    isLoginSuccess: [true]
  });
  constructor(
    private authService: AuthenticationService, private fb: FormBuilder, private route: ActivatedRoute, private router: Router
  ) {

  }

  ngOnInit() {
    
  }

  login() {
    console.log(this.loginControls.value);
    if (this.loginControls.valid) {
      this.authService.login(this.loginControls.value.email, this.loginControls.value.password).subscribe((res) => {
        if (res != null) {
          this.router.navigate(['/dashboard'], { relativeTo: this.route });
        } else {
          this.loginControls.value.isLoginSuccess = false;
        }
      });
    }
  }

}
