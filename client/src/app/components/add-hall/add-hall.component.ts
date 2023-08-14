import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { min } from 'rxjs';
import { Hall } from 'src/app/model/hall.model';

@Component({
  selector: 'app-add-hall',
  templateUrl: './add-hall.component.html',
  styleUrls: ['./add-hall.component.scss']
})
export class AddHallComponent {
  cities: string[] = ['tehran', 'karaj',]

  prices: string[] = ['to highe', 'highe', 'medium', 'economic']

  // feature= new FormControl('');
  // Features: string[] = ['parking', 'WeddingRoom', 'FreeInternet', 'Coffeshop', 'Elevator'];

  hallRes: Hall | undefined

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  hallFg = this.fb.group({
    nameCtrl: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(9)]],
    cityCtrl: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(8)]],
    priceLevelCtrl: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(10)]],
    capacityCtrl: ['', [Validators.required, Validators.min(50), Validators.max(2000)]],
    phoneNumberCtrl: ['', [Validators.required]],
    parkingCtrl: [''],
    weddingRoomCtrl: [''],
    freeWifiCtrl: [''],
    cofeCtrl: [''],
    elevatorCtrl: [''],
    // lightingCtrl: [''],
  });

  submitHall(): void {
    console.log(this.hallFg.value)

    let hall: Hall = {
      name: this.NameCtrl.value,
      city: this.CityCtrl.value,
      priceLevel: this.PriceLevelCtrl.value,
      capacity: this.CapacityCtrl.value,
      phoneNumber: this.PhoneNumberCtrl.value,
      parking: this.ParkingCtrl.value,
      weddingRoom: this.WeddingRoomCtrl.value,
      freeWifi: this.FreeWifiCtrl.value,
      cofe: this.CofeCtrl.value,
      elevator: this.ElevatorCtrl.value,
      // lighting: this.LightingCtrl.value,
    }

    this.http.post<Hall>('http://localhost:5000/api/hallordinary/register', hall).subscribe(
      {
        next: res => {
          this.hallRes = res;
          console.log(res);
        }
      }
    );

  }
  get NameCtrl(): FormControl {
    return this.hallFg.get('nameCtrl') as FormControl
  }
  get CityCtrl(): FormControl {
    return this.hallFg.get('cityCtrl') as FormControl
  }
  get PriceLevelCtrl(): FormControl {
    return this.hallFg.get('priceLevelCtrl') as FormControl
  }
  get CapacityCtrl(): FormControl {
    return this.hallFg.get('capacityCtrl') as FormControl
  }
  get PhoneNumberCtrl(): FormControl {
    return this.hallFg.get('phoneNumberCtrl') as FormControl
  }
  get ParkingCtrl(): FormControl {
    return this.hallFg.get('parkingCtrl') as FormControl
  }
  get WeddingRoomCtrl(): FormControl {
    return this.hallFg.get('weddingRoomCtrl') as FormControl
  }
  get FreeWifiCtrl(): FormControl {
    return this.hallFg.get('freeWifiCtrl') as FormControl
  }
  get CofeCtrl(): FormControl {
    return this.hallFg.get('cofeCtrl') as FormControl
  }
  get ElevatorCtrl(): FormControl {
    return this.hallFg.get('elevatorCtrl') as FormControl
  }
  // get LightingCtrl(): FormControl {
  //  
  // return this.hallFg.get('lightingCtrl') as FormControl
  // }
}

