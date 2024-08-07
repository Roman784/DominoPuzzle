mergeInto(LibraryManager.library, {

    InitYSDKExtern: function(id)
    {
        initSDK(id);
    },

    ShowRewardedVideoExtern : function(id) 
    {
        gameInstance.SendMessage('YandexSDK', 'InvokeCallback', id);

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

    GetLanguageExtern: function () 
    {
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);

        return buffer;
    },

});