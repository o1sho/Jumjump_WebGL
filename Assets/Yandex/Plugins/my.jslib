  mergeInto(LibraryManager.library, {

    Hello: function () {
      window.alert("Hello, world!");
      console.log("Hello world!");
    },


    RateGame: function () {
      ysdk.feedback.canReview()
          .then(({ value, reason }) => {
              if (value) {
                  ysdk.feedback.requestReview()
                      .then(({ feedbackSent }) => {
                          console.log(feedbackSent);
                      })
              } else {
                  console.log(reason)
              }
          })
    },

    ShowAdv: function(){
      ysdk.adv.showFullscreenAdv({
        callbacks: {
          onClose: function(wasShown) {
          // some action after close
          },
          onError: function(error) {
          // some action on error
          }
        }
      })
    },

    ShowRewardAdv: function(){
      ysdk.adv.showRewardedVideo({
        callbacks: {
          onOpen: () => {
            console.log('Video ad open.');
          },
          onRewarded: () => {
            console.log('Rewarded!');
            myGameInstance.SendMessage('Yandex', 'RewardAdvButton');
          },
          onClose: () => {
            console.log('Video ad closed.');
          }, 
          onError: (e) => {
            console.log('Error while open video ad:', e);
          }
        }
      })
    },

    LeaderBoard: function(maxScore){
      ysdk.getLeaderboards()
      .then(lb => {
        lb.setLeaderboardScore('leader', maxScore);
      });
    },


  });