import { Component, OnInit } from '@angular/core';
import { ApiService, Driver } from '../../services/api.service';

@Component({
  selector: 'app-drivers',
  templateUrl: './drivers.component.html',
  styleUrls: ['./drivers.component.css']
})
export class DriversComponent {
  protected drivers?: Driver[];

  public constructor(private api: ApiService) {
    api.drivers_Get()
      .subscribe(drivers => this.drivers = drivers || []);
  }

  protected deleteDriver(deletedDriver: Driver): void {
    const deleteConfirmed = confirm(`
      Are you sure you want to delete this driver?\r\n
      ${deletedDriver.name} ${deletedDriver.surname}\r\n
      This operation is irreversible!
    `)

    if (!deleteConfirmed) {
      return;
    }

    this.api.drivers_DeleteById(deletedDriver.id!)
      .subscribe(x => this.drivers = this.drivers?.filter(x => x.id != deletedDriver.id));
  }
}
