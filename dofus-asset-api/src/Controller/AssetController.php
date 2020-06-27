<?php

namespace App\Controller;

use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\HttpKernel\Exception\BadRequestHttpException;
use Symfony\Component\Routing\Annotation\Route;

class AssetController extends AbstractController
{
    /**
     * @Route("/assets/{route}", requirements={"route"=".+"}, methods={"GET"}, name="app_asset")
     */
    public function index(string $route)
    {
        $directories = explode("/", 'assets/'.$route);

        if (empty($directories))
            throw new BadRequestHttpException();

        $directoriesPath = "";

        $fileName = $directories[count($directories) - 1];

        if (count($directories) > 1) {
            //remove fileName from directories
            array_pop($directories);

            $directoriesPath = implode('/', $directories);

            if (!is_dir($directoriesPath)) {
                mkdir($directoriesPath, 0777, true);
            }
        }

        $finfo = new \finfo(FILEINFO_MIME);
        $fileContent = file_get_contents($_ENV['BASE_ASSETS_URL'] . $route);
        file_put_contents($directoriesPath.'/'.$fileName, $fileContent);


        return new Response($fileContent, 200, [
            'content-type' => $finfo->buffer($fileContent)
        ]);
    }
}