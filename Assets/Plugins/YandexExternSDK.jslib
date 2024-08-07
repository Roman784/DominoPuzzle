mergeInto(LibraryManager.library, {

    InitYSDKExtern: function(id)
    {
        initSDK(id);
    },

    ShowRewardedVideoExtern : function(id) 
    {
        ysdk.adv.showRewardedVideo({
            callbacks: {
                onOpen: () => {
                    gameInstance.SendMessage('YandexSDK', 'StopGame');
                    console.log('Video ad open.');
                },
                onRewarded: () => {
                    gameInstance.SendMessage('YandexSDK', 'InvokeCallback', id);
                    console.log('Rewarded!');
                },
                onClose: () => {
                    gameInstance.SendMessage('YandexSDK', 'ContinueGame');
                    console.log('Video ad closed.');
                }, 
                onError: (e) => {
                    gameInstance.SendMessage('YandexSDK', 'ContinueGame');
                    console.log('Error while open video ad:', e);
                }
            }
        })
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