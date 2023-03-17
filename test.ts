import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { AppModule } from "./app/app.module";
import { enableProdMode } from "@angular/core";

// NOTE: Comment the following line for local development
enableProdMode();

platformBrowserDynamic()
  .bootstrapModule(AppModule)
  .catch(err => console.error(err));
