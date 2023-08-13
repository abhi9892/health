import { IonContent, IonHeader, IonPage, IonTitle, IonToolbar } from '@ionic/react';
import { ExploreContainer } from '../components/ExploreContainer';
import { RouteComponentProps } from 'react-router';

const Home: React.FC<RouteComponentProps> = () => {
  return (
    <IonPage>
      <ExploreContainer />
    </IonPage>
  );
};

export default Home;
