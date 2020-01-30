import { HttpResponse } from '@angular/common/http';
import saveAs from 'file-saver';
import { AssetRoutes } from '../assets/assets-routes';
import { AssetModel } from '../assets/assets.model';

const getFileNameFromContentDisposition = (response: HttpResponse<Blob>) => {
  const header = response.headers.get('Content-Disposition');
  const result = header.split(';')[1].trim().split('=')[1];
  return result.replace(/"/g, '');
}

export const saveFile = (response: HttpResponse<Blob>, fileName?: string) =>
{
  const file = fileName || getFileNameFromContentDisposition(response);
  saveAs(response.body, file);
}

export const getShareFileUrl = (asset: AssetModel): string => {
    const hostUrl = window.location.origin;
    return `${hostUrl}${AssetRoutes.shareRoute}?id=${asset.id}&fileId=${encodeURIComponent(asset.fileId)}`;
}
