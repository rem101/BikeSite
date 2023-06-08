export interface Bike {
  bikeId: string | undefined;
  model: string;
  price: number;
  frameSize: number;
  brand: BikeBrand;
}

export interface BikeBrand {
  BikeBrandId: string;
  Brand: string;
}
