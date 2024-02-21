import { Component, Input, SimpleChange } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent {
  @Input() errorMessage: string = '';
  @Input() dataSource: any;
  @Input() displayedColumns: string[] = [];
  @Input() isLoading: boolean = false;
  @Input() route: string = '';

  constructor(private router: Router) {
  }

  onRowClick(row: any) {
    console.log(row)
    let item;
    if (row.id) {
      item = row.id;
    } else if (row.gameAlias) {
      item = row.gameAlias;
    }

    if (item) {
      console.log(item);
      this.router.navigateByUrl(`/${this.route}/${item}`);
    } else {
      console.log("I don't know where to navigate");
    }
  }
}
