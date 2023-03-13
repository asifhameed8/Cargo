import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-shipper',
  templateUrl: './shipper.component.html',
  styleUrls: ['./shipper.component.css']
})
export class ShipperComponent implements OnInit {
  shipperList: any;
  shipperDetails : any;
  baseUrl = environment.url;

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.ListOfShipper();
  }

  ListOfShipper() {
    this.http.get<Shipper>(this.baseUrl + '/Shipper/GetAllShipper').subscribe(data => {
      this.shipperList = data;
    }, error => console.error(error));
  }

  getShipperDetails(id:number){
    this.http.get<Shipper>(this.baseUrl + '/Shipper/GetShipperDetailsByShipperId/' + id).subscribe(data => {
      this.shipperDetails = data;
    }, error => console.error(error));
  }

}

interface Shipper {
  shipperId: number,
  shipperName: string
}
