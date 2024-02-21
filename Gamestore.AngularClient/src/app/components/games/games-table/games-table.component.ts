import { Component } from '@angular/core';
import { GameListingModel } from '../../../../models/GameListingModel';
import { GamesService } from '../../../services/gamesService';
import { MatBottomSheet, MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { AddGameComponent } from '../add-game/add-game.component';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';
import { HttpService } from '../../../services/httpService';
import { DisplayedFilters } from '../../shared/filtering-options/displayedFilters';

@Component({
  selector: 'app-games-table',
  templateUrl: './games-table.component.html',
  styleUrls: ['./games-table.component.css']
})
export class GamesTableComponent {

  totalGamesCount: number = 0;
  pageIndex?: number = 0;
  pageSize?: number = 10;
  filterQueryParameters: string = '';
  paginationQueryParameters: string = '';
  paginatorPageSizeOptions = [10, 20, 50, 100, 999];
  isLoading: boolean = false;
  errorMessage: string = '';
  dataSource = new MatTableDataSource<GameListingModel>
  displayedColumns = [
    'name',
    'price',
    'unitInStock',
    'genresNames',
    'platformsNames',
    'publisher',
    'discontinued',
    'publishDate',
    'viewCount',
    'creationDate'
  ];
    displayedFilters: DisplayedFilters = {
    dateRange: true,
    gameName: true,
    genre: true,
    platform: true,
    priceRange: true,
    publisher: true,
    sortOptions: ['None', 'MostPopular', 'MostCommented', 'PriceAscending', 'PriceDescending', 'CreationDate'],
  };

  constructor(
    private gamesHttpService: GamesService,
    private bottomSheet: MatBottomSheet,
    private httpService: HttpService,
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

  onFilter(queryParameters: string) {
    this.filterQueryParameters = queryParameters;
    this.getTableDataSource();
  }

  openAddGameBottomSheet() {
    const addGameBottomSheet: MatBottomSheetRef = this.bottomSheet.open(
      AddGameComponent,
      {
        disableClose: true,
      }
    );

    addGameBottomSheet.afterDismissed().subscribe(async (result) => {
      if (result?.event === "gameAddedSuccesfully") {
        this.getTableDataSource();
      }
    });
  }

  private async getTableDataSource(): Promise<void> {
    const queryParameters = this.filterQueryParameters + this.paginationQueryParameters;
    this.isLoading = true;
    try {
      this.dataSource.data = await this.gamesHttpService.getAllGames(queryParameters);
      this.totalGamesCount = this.httpService.totalGamesCount;

      this.isLoading = false;
    } catch (error: any) {
      this.isLoading = false;
      this.errorMessage = error.message
    }
  }

  async handlePaginatorEvent(e: PageEvent) {
    this.pageIndex = e.pageIndex;
    this.pageSize = e.pageSize;
    const pageIndexQuery = `&pageIndex=${this.pageIndex}`;
    const pageSizeQuery = `&pageSize=${this.pageSize}`;
    this.paginationQueryParameters = `${pageIndexQuery}${pageSizeQuery}`
    this.getTableDataSource();
  }

  showAll() {
    this.pageIndex = 0;
    this.pageSize = this.httpService.totalGamesCountFromHeader;
    const pageIndexQuery = `&pageIndex=${this.pageIndex}`;
    const pageSizeQuery = `&pageSize=${this.pageSize}`;
    this.paginationQueryParameters = `${pageIndexQuery}${pageSizeQuery}`
    this.getTableDataSource();
  }
}
