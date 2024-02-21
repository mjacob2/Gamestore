import { Component } from '@angular/core';
import { GamesService } from '../../../services/gamesService';
import { ActivatedRoute, Params } from '@angular/router';
import { GetGameByAlias } from '../../../../models/GetGameByAlias';
import { DownloadService } from '../../../services/downloadService';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-game-details',
  templateUrl: './game-details.component.html',
  styleUrls: ['./game-details.component.css']
})
export class GameDetailsComponent {
  alias: string = '';
  game?: GetGameByAlias;
  errorMessage: string = '';
  isLoading: boolean = false;

  constructor(
    private gamesHttpService: GamesService,
    private downloadService: DownloadService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
  ) { }

  async ngOnInit() {
    this.isLoading = true;
    this.route.params.subscribe(async (params: Params) => {
      this.alias = params['gameAlias'];
    });

    await this.gamesHttpService
      .getGameByAlias(this.alias)
      .then(game => {
        this.game = game;
        this.isLoading = false;
      })
      .catch(error => {
        this.isLoading = false;
        this.errorMessage = error.message;
      });
  }

  downloadGame() {
    this.downloadService.downloadGame(this.alias).subscribe({
      next: data => {
        const blob = new Blob([data], { type: 'text/plain' });
        const url = window.URL.createObjectURL(blob);
        var link = document.createElement('a');
        link.href = url;
        link.download = `${this.alias}-game.txt`;
        link.click();
      },
      error: err => {
        console.log(err)
        this.errorMessage = err.message;
      }
    });
  }

  async buyGame() {
    this.isLoading = true;
    await this.gamesHttpService
      .buyGame(this.alias)
      .then(game => {
        this.isLoading = false;
        this.snackBar.open(
          'Game added to cart',
          'Close',
          {
            duration: 3000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
      })
      .catch(error => {
        this.isLoading = false;
        this.errorMessage = error.message;
      });
  }

}
