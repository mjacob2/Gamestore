import { Component } from '@angular/core';
import { GetPublisherByIdModel } from '../../../../models/GetPublisherByIdModel';
import { PublishersService } from '../../../services/publishersService';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-publisher-details',
  templateUrl: './publisher-details.component.html',
  styleUrls: ['./publisher-details.component.css']
})
export class PublisherDetailsComponent {
  id: string = '';
  publisher?: GetPublisherByIdModel;
  errorMessage: string = '';
  isLoading: boolean = false;

  constructor(
    private publishersHttpService: PublishersService,
    private route: ActivatedRoute,
  ) {}


  async ngOnInit() {
    this.isLoading = true;
    this.route.params.subscribe(async (params: Params) => {
      this.id = params['publisherId'];
    });

    await this.publishersHttpService
      .getPublisherById(this.id)
      .then(publisher => {
        this.publisher = publisher;
        this.isLoading = false;
      })
      .catch(error => {
        this.isLoading = false;
        this.errorMessage = error.message;
      });
  }
}
