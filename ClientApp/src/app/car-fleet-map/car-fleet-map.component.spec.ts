import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarFleetMapComponent } from './car-fleet-map.component';

describe('CarFleetMapComponent', () => {
  let component: CarFleetMapComponent;
  let fixture: ComponentFixture<CarFleetMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarFleetMapComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarFleetMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
