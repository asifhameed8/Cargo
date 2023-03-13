import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-quotes-details',
  templateUrl: './quotes-details.component.html',
  styleUrls: ['./quotes-details.component.css']
})
export class QuotesDetailsComponent implements OnInit {
  quotesDetail: any;
  shortList: any;
  mediumList: any;
  largeList: any;
  baseUrl = environment.url;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.quoteDetail();
    this.ListOfAuthorQuotes();
  }

  quoteDetail() {
    this.http.get(this.baseUrl + '/Quotes/GetRandomQuotes').subscribe(data => {
      this.quotesDetail = data;
    }, error => console.error(error));
  }

  ListOfAuthorQuotes() {
    this.http.get<QuotesList>(this.baseUrl + '/Quotes/GetAllAuthor').subscribe(data => {
      this.shortList = data.result.results.filter((o: any) => o.content.split(/\s+/).length < 10);
      this.mediumList = data.result.results.filter((o: any) => o.content.split(/\s+/).length > 11 && o.content.split(/\s+/).length < 20);
      this.largeList = data.result.results.filter((o: any) => o.content.split(/\s+/).length > 21);
    }, error => console.error(error));
  }

}

interface QuotesList {
  count: number;
  totalCount: number;
  page: number;
  totalPages: number;
  lastItemIndex: number;
  result: any;
}
