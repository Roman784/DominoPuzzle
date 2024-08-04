mergeInto(LibraryManager.library, {

    ShowRewardedVideoExtern : function () 
    {
        console.log("aboba");
        myGameInstance.SendMessage('YandexSDKReceiver', 'StopGame');
        // ysdk.adv.showRewardedVideo({
        //     callbacks: {
        //         onOpen: () => {
        //             myGameInstance.SendMessage('YandexReceiver', 'StopGame');
        //             console.log('Video ad open.');
        //         },
        //         onRewarded: () => {
        //             myGameInstance.SendMessage('YandexReceiver', 'OnRewarded');
        //             console.log('Rewarded!');
        //         },
        //         onClose: () => {
        //             myGameInstance.SendMessage('YandexReceiver', 'ContinueGame');
        //             console.log('Video ad closed.');
        //         }, 
        //         onError: (e) => {
        //             myGameInstance.SendMessage('YandexReceiver', 'ContinueGame');
        //             console.log('Error while open video ad:', e);
        //         }
        //     }
        // })
    },

});