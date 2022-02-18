import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subscription, timer } from 'rxjs';

@Component({
  selector: 'app-market-company',
  templateUrl: './market-company.component.html',
  styleUrls: ['./market-company.component.css']
})
export class MarketCompanyComponent implements OnInit, OnDestroy {
  http: HttpClient;
  baseUrl: string;
  public markets: MarketCompany[] = [];
  isEdit = false;
  editIndex = -1;
  tableIndex = -1;
  subscription: Subscription = new Subscription();
  everyFiveSeconds: Observable<number> = timer(0, 5000);


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.getData();
  }

  getData() {
    this.http.get<MarketCompany[]>(this.baseUrl + 'market/getall').subscribe(result => {
      this.markets = result;
    });
  }

  cancelEdit() {
    this.isEdit = false;
    this.editIndex = -1;
    this.tableIndex = -1;
  }

  saveChanges(cId: number, mId: number) {
    var newValue = parseFloat((<HTMLInputElement>document.getElementById("changedPrice")).value);
    newValue = parseFloat(newValue.toFixed(2));
    //console.log(cId, mId, newValue);

    this.http.post<ResponseResult>(this.baseUrl + 'market/changeprice',
      {
        'CompanyId': cId,
        'MarketId': mId,
        'NewPrice': newValue
      }).subscribe(res => {
        if (res.status == 0) {
          // after successful post
          this.markets.filter(x => x.marketId == mId)[0]
            .companyList.filter(y => y.companyId == cId)[0].price = newValue;
        }
        else {
          // show error
          console.log(res.message);
        }
      });

    this.cancelEdit();
  }

  enableEdit(i: number, mi: number) {
    this.isEdit = true;
    this.editIndex = i;
    this.tableIndex = mi;

    //console.log(i, mi);
  }

  ngOnInit() {
    this.subscription = this.everyFiveSeconds.subscribe(() => {
      if (!this.isEdit)
        this.getData();
    })
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}

interface MarketCompany {
  marketId: number;
  marketName: string;
  companyList: Company[];
}

interface Company {
  companyId: number;
  companyName: string;
  price: number;
}

interface ResponseResult {
  status: number;
  message: string;
}
