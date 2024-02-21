import { Component } from '@angular/core';
import { MatBottomSheet, MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { AddPlatformComponent } from './components/platforms/add-platform/add-platform.component';
import { AddGenreComponent } from './components/genres/add-genre/add-genre.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Gamestore.AngularClient';

  constructor(
    private bottomSheet: MatBottomSheet,
  ) { }

  openAddPlatformBottomSheet() {
    const addPlatformBottomSheet: MatBottomSheetRef = this.bottomSheet.open(
      AddPlatformComponent,
      {
        disableClose: true,
      }
    );

    addPlatformBottomSheet.afterDismissed().subscribe(async (result) => {
      if (result?.event === "gameAddedSuccesfully") {
        console.log("Added platform!!")
      }
    });
  }

  openAddGenreBottomSheet() {
    const addGenreBottomSheet: MatBottomSheetRef = this.bottomSheet.open(
      AddGenreComponent,
      {
        disableClose: true,
      }
    );

    addGenreBottomSheet.afterDismissed().subscribe(async (result) => {
      if (result?.event === "genreAddedSuccesfully") {
        console.log("Added genre!!")
      }
    });
  }
}

