import { Component } from '@angular/core';
import { ApiService, Driver } from '../../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-driver-add',
  templateUrl: './driver-add.component.html',
  styleUrls: ['./driver-add.component.css']
})
export class DriverAddComponent {
  protected driver: Driver;

  public constructor(private api: ApiService, private router: Router) {
    this.driver = new Driver();
  }

  protected get canAddDriver(): boolean {
    return this.driver.name != null
      && this.driver.name.length > 0
      && this.driver.surname != null
      && this.driver.surname.length > 0;
  }
  protected addDriver(): void {
    if (!this.canAddDriver) {
      return;
    }

    this.api.drivers_Create(this.driver.name, this.driver.surname)
      .subscribe(res => this.router.navigate(['drivers']));
  }
}
