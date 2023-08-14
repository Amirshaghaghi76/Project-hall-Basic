import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Counseling } from 'src/app/model/counseling.model ';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  counselingRes: Counseling | undefined;

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  counselingFg = this.fb.group({
    phoneNumberCtrl: ['', [Validators.minLength(11), Validators.maxLength(11), Validators.required]]
  });

  registerCounseling(): void {
    console.log(this.counselingFg.value);

    let counseling: Counseling = {
      phoneNumber: this.PhoneNumberCtrl.value
    }

    this.http.post<Counseling>('http://localhost:5000/api/advice/register', counseling).subscribe(
      {
        next: res => {
          this.counselingRes = res;
          console.log(res);
        }
      }
    );
  }

  get PhoneNumberCtrl(): FormControl {
    return this.counselingFg.get('phoneNumberCtrl') as FormControl;
  }
}

