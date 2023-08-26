import { Component, OnInit } from '@angular/core';
import { ApiService, Driver } from '../../services/api.service';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';

@Component({
  selector: 'app-driver-update',
  templateUrl: './driver-update.component.html',
  styleUrls: ['./driver-update.component.css']
})
export class DriverUpdateComponent implements OnInit {
  protected driver: Driver;

  public constructor(private api: ApiService, private router: Router, private route: ActivatedRoute) {
    this.driver = new Driver();
  }

  public ngOnInit(): void {
    this.route.paramMap
      .subscribe(x => {
        const driverId = +x.get('id')!;

        if (driverId == null) {
          return;
        }

        this.api.drivers_GetById(driverId)
          .subscribe(driver => this.driver = driver);
      });
  }

  protected get canAddDriver(): boolean {
    return this.driver.id != null
      && this.driver.name != null
      && this.driver.name.length > 0
      && this.driver.surname != null
      && this.driver.surname.length > 0;
  }
  protected addDriver(): void {
    if (!this.canAddDriver) {
      return;
    }

    this.api.drivers_Update(this.driver.id!, this.driver.name, this.driver.surname)
      .subscribe(res => this.router.navigate(['drivers']));
  }
}
