import { Component } from '@angular/core';
import { GetAllPublishersModel } from '../../../../models/GetAllPublishersModel';
import { PublishersService } from '../../../services/publishersService';
import { MatBottomSheet, MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { AddPublisherComponent } from '../add-publisher/add-publisher.component';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-publishers-table',
  templateUrl: './publishers-table.component.html',
  styleUrls: ['./publishers-table.component.css']
})
export class PublishersTableComponent {
  isLoading: boolean = false;
  errorMessage: string = '';
  publishers: any;
  dataSource = new MatTableDataSource<GetAllPublishersModel>();
  displayedColumns = [
    'companyName'
  ];

  constructor(
    private publishersHttpService: PublishersService,
    private bottomSheet: MatBottomSheet,
  ) { }

  async ngOnInit() {
    this.isLoading = true;
    try {
      await this.getTableDataSource();
      this.isLoading = false;
    } catch (error: any) {
      this.isLoading = false;
      this.errorMessage = error.message
    }
  }

  openAddPublisherBottomSheet() {
    const bottomSheetRef: MatBottomSheetRef = this.bottomSheet.open(
      AddPublisherComponent,
      {
        disableClose: true,
      }
    );

    bottomSheetRef.afterDismissed().subscribe(async (result) => {
      if (result?.event === "publisherAddedSuccesfully") {
        this.getTableDataSource();
      }
    });
  }

  private async getTableDataSource(): Promise<void> {
    this.dataSource.data = await this.publishersHttpService.getAllPublishers();
  }
}
