import { Component, OnInit } from '@angular/core';
import ArcGISMap from "@arcgis/core/Map.js";
import MapView from "@arcgis/core/views/MapView.js";

@Component({
  selector: 'app-car-fleet-map',
  templateUrl: './car-fleet-map.component.html',
  styleUrls: ['./car-fleet-map.component.css']
})
export class CarFleetMapComponent implements OnInit {

  public ngOnInit(): void {
    const map = new ArcGISMap({
      basemap: "streets-vector"
    });

    const view = new MapView({
      map: map,
      container: "map",
      center: [-118.244, 34.052],
      zoom: 12
    });
  }

}
