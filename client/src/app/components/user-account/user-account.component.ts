import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { User } from 'src/app/model/user.model';
import { userLogin } from 'src/app/model/userLogin.model';


@Component({
  selector: 'app-user-account',
  templateUrl: './user-account.component.html',
  styleUrls: ['./user-account.component.scss']
})
export class UserAccountComponent {
  userRes: User | undefined;
  userLogin:userLogin|undefined;


  constructor(private fb: FormBuilder, private http: HttpClient) { }

  userFg = this.fb.group({
    nameCtrl: ['', [Validators.minLength(3), Validators.maxLength(10), Validators.required]],
    passwordCtrl: ['', [Validators.minLength(6), Validators.maxLength(15), Validators.required]],
    confrimPasswordCtrl: ['', [Validators.minLength(6), Validators.maxLength(15), Validators.required]],
    emailCtrl: ['', [Validators.pattern(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$/), Validators.required]],
    ageCtrl: ['', [Validators.min(18), Validators.max(99)]]
  })

  get NameCtrl(): FormControl {
    return this.userFg.get('nameCtrl') as FormControl;
  }
  get PasswordCtrl(): FormControl {
    return this.userFg.get('passwordCtrl') as FormControl;
  }
  get ConfrimPasswordCtrl(): FormControl {
    return this.userFg.get('confrimPasswordCtrl') as FormControl;
  }
  get EmailCtrl(): FormControl {
    return this.userFg.get('emailCtrl') as FormControl;
  }
  get AgeCtrl(): FormControl {
    return this.userFg.get('ageCtrl') as FormControl;
  }

  registerUser(): void {
    console.log(this.userFg.value);

    let account: User = {
      name: this.NameCtrl.value,
      password: this.PasswordCtrl.value,
      confrimPassword: this.ConfrimPasswordCtrl.value,
      email: this.EmailCtrl.value,
      age: this.AgeCtrl.value
    }

    this.http.post<userLogin>('http://localhost:5000/api/user/register', account).subscribe(
      {
        next: res => {
          this.userLogin = res;
          console.log(res);
        }
      }
    );
  }

  ClearForm(): void {
    this.userFg.reset();
  }
}
