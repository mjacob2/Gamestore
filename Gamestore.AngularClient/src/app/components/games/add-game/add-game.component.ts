import { Component } from '@angular/core';
import { GamesService } from '../../../services/gamesService';
import { AddGameModel } from '../../../../models/AddGameModel';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { GetAllGenresModel } from '../../../../models/GetAllGenresModel';
import { GenresService } from '../../../services/genresService';
import { GetAllPlatformsModel } from '../../../../models/GetAllPlatformsModel';
import { NgForm } from '@angular/forms';
import { PlatformsService } from '../../../services/platformsService';
import { GetAllPublishersModel } from '../../../../models/GetAllPublishersModel';
import { PublishersService } from '../../../services/publishersService';

@Component({
  selector: 'app-add-game',
  templateUrl: './add-game.component.html',
  styleUrls: ['./add-game.component.css']
})
export class AddGameComponent {
  isLoading: boolean = false;
  errorMessage: string = '';
  genres: GetAllGenresModel[] = [];
  platforms: GetAllPlatformsModel[] = [];
  publishers: GetAllPublishersModel[] = [];
  selectedGenres: any[] = [];
  selectedPlatforms: any[] = [];

  constructor(
    private httpGamesService: GamesService,
    private httpGenresService: GenresService,
    private httpPlatformsService: PlatformsService,
    private httpPublishersService: PublishersService,
    private bottomSheetRef: MatBottomSheetRef<AddGameComponent>,

  ) { }

  async ngOnInit() {
    this.genres = await this.httpGenresService.getAllGenres();
    this.platforms = await this.httpPlatformsService.getAllPlatforms();
    this.publishers = await this.httpPublishersService.getAllPublishers();
  }

  async onSubmit(form: NgForm) {
    console.log(form)
    if (!form.valid) {
      this.errorMessage = "Fields marked red are obligatory";
    } else {
      this.errorMessage = "";
      this.isLoading = true;
      var gameToAdd = form.value;

      if (!gameToAdd.discontinued) {
        gameToAdd.discontinued = false;
      }

      console.log(gameToAdd);

      try {
        await this.httpGamesService.addGame(gameToAdd);
        this.bottomSheetRef.dismiss({ event: 'gameAddedSuccesfully' });
        this.isLoading = false;
      } catch (error: any) {
        this.isLoading = false;
        this.errorMessage = error.message;
      }
    }
  }

  closeBottomSheet(): void {
    this.bottomSheetRef.dismiss();
  }
}
