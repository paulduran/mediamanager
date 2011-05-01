
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Media.BE;
using Media.BC;

namespace MediaManager2
{
    public partial class EpisodeMaintenance : UserControl, MediaItemBindable
    {
        private int oldEpisodeRowIndex = -1;
        private TvSeries showDetails;

        private List<ISeason> allSeasons;

        public EpisodeMaintenance()
        {
            InitializeComponent();
        }

        private SeasonHelperFactory seasonHelperFactory;

        public SeasonHelperFactory SeasonHelperFactory
        {
            get { return seasonHelperFactory; }
            set { seasonHelperFactory = value; }
        }

        /// <summary>
        /// obtains the list of seasons using the season helper
        /// </summary>
        public List<ISeason> AllSeasons
        {
            get
            {
                if (allSeasons == null)
                {
                    ISeasonHelper helper = SeasonHelperFactory.GetSeasonHelperForUrl(showDetails.EpisodeListUrl);
                    if (helper != null)
                    {
                        allSeasons = helper.GetSeasons(showDetails.EpisodeListUrl);
                    }
                }
                return allSeasons;
            }
        }

        /// <summary>
        /// Reads from the specified media item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void ReadFrom(MediaItem item)
        {
            if (item is TvSeries)
                showDetails = (TvSeries)item;
            allSeasons = null;
            lstSeasons.Items.Clear();
            grdEpisodes.DataSource = null;

            foreach (MediaItem child in item.Children)
            {
                if (child is ISeason)
                {
                    lstSeasons.Items.Add(child);
                }
            }
        }

        public void WriteTo(MediaItem item)
        {
            int rowIndex = grdEpisodes.CurrentCellAddress.Y;
            if (rowIndex != -1 )
            {
                // rebind the episode
                ISeason season = (ISeason)lstSeasons.SelectedItem;
                season.Episodes[rowIndex] = episodeDetails.Episode;
            }
            //item.Components["TvShowDetails"] = showDetails;
        }

        private void EpisodeMaintenance_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// allows the user to select which season they wish to add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (showDetails != null)
            {
                if( AllSeasons != null )
                {
                    ResultSelector selector = new ResultSelector();
                    selector.Items = AllSeasons;
                    selector.ItemSelectedEvent += new ResultSelector.ItemSelected(selector_ItemSelectedEvent);
                    selector.Visible = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstSeasons.SelectedItem == null)
                return;

            ISeason season = (ISeason)lstSeasons.SelectedItem;
            lstSeasons.Items.Remove(season);
            showDetails.Seasons.Remove(season);
            grdEpisodes.DataSource = null;
        }

        /// <summary>
        /// adds the specified season object to the tvseries object
        /// </summary>
        /// <param name="season"></param>
        private void AddSeason(ISeason newSeason)
        {
            // look for existing season and merge
            foreach (ISeason season in lstSeasons.Items)
            {
                if (season.SeasonNumber == newSeason.SeasonNumber)
                {
                    MergeSeasons(season, newSeason);
                    return;
                }
            }
            // existing season not found. add new one
            lstSeasons.Items.Add(newSeason);

            if (newSeason is MediaItem)
            {
                showDetails.Children.Add(newSeason);
            }           
        }

        private void MergeSeasons(ISeason origSeason, ISeason newSeason)
        {
            foreach (IEpisode newEp in newSeason.Episodes)
            {
                IEpisode originalEp = origSeason[newEp.EpisodeNumber];
                if (originalEp == null)
                    origSeason.Episodes.Add(newEp);
                else if (originalEp is Episode)
                {
                    MergeEpisodes((Episode)originalEp, newEp);
                }
                else
                {
                    // FIXME: what to do here?
                }
            }
        }

        /// <summary>
        /// we assume that the new episode has more up-to-date information
        /// but we dont want to lose any info that is not retrieved automatically
        /// such as file path so we will only merge what we safely can
        /// </summary>
        /// <param name="origEp">original episode</param>
        /// <param name="newEp">new episode</param>
        private void MergeEpisodes(Episode origEp, IEpisode newEp)
        {
            origEp.AiringDateTime = newEp.AiringDateTime;
            if (string.IsNullOrEmpty(origEp.Description))
                origEp.Description = newEp.Description;
            if (origEp.DetailsURI == null )
                origEp.DetailsURI = newEp.DetailsURI;
            if (origEp.File == null)
                origEp.File = newEp.File;            
            origEp.Title = newEp.Title;
        }

        /// <summary>
        /// handle the itemselected event from the result selector dialog. we simply add the
        /// selected season
        /// </summary>
        /// <param name="selectedItem"></param>
        private void selector_ItemSelectedEvent(object selectedItem)
        {
            AddSeason((ISeason)selectedItem);
        }

        /// <summary>
        /// shows the episode list for the selected season
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSeasons_Click(object sender, EventArgs e)
        {
            if (lstSeasons.SelectedItem == null)
                return;

            ISeason season = (ISeason)lstSeasons.SelectedItem;
            grdEpisodes.DataSource = season.Episodes;
            oldEpisodeRowIndex = -1;
        }

        /// <summary>
        /// returns true if the media file and tv series are compatible. to check this we 
        /// condense the titles for both objects, removing whitespace and removing periods , underscores and dashes.
        /// if the two titles are the same after that, they are considered compatible.
        /// </summary>
        /// <param name="mfi"></param>
        /// <param name="series"></param>
        /// <returns>true if the media file and tv series are compatible, otherwise false</returns>
        private bool IsCompatible( MediaFile mfi, TvSeries series)
        {
            string condensedMfiTitle = mfi.Title.ToLower().Replace(" ", "").Replace(".", "").Replace("_", "").Replace("-", "").Replace(":", "").Replace("'", "").Replace("(", "").Replace(")", "");
            string condensedSeriesTitle = series.Title.ToLower().Replace(" ", "").Replace(".", "").Replace("_", "").Replace("-", "").Replace(":", "").Replace("'", "").Replace("(", "").Replace(")", "");
            return condensedMfiTitle.Equals(condensedSeriesTitle);

        }

        /// <summary>
        /// called at the completion of a drop operation. we grab the list of media files
        /// and 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EpisodeMaintenance_DragDrop(object sender, DragEventArgs e)
        {
            MediaFileNameParser parser = new MediaFileNameParser();
            List<MediaFile> mediaItems = new List<MediaFile>();
            foreach (string fileName in GetMediaFiles(e))
            {
                MediaFile mfi = parser.Parse(fileName);
                if (mfi.FileType == MediaFileType.TvEpisode)
                {
                    if (IsCompatible(mfi, showDetails))
                    {
                        mediaItems.Add(mfi);
                    }
                }
            }
            TvEpisodeImportDialog importDialog = new TvEpisodeImportDialog();
            importDialog.MediaItemsSelected += new SelectedMediaItemsHandler(importDialog_MediaItemsSelected);
            importDialog.MediaItems = mediaItems;            
            importDialog.Show(this);            
        }
         
        /// <summary>
        /// handles the event from the episode import dialog. we go through each of the MediaFileInfo
        /// objects and if there is no season object already, we add it. we then set the file info
        /// for the appropriate episode in the season
        /// </summary>
        /// <param name="selectedMediaItems"></param>
        private void importDialog_MediaItemsSelected(List<MediaFile> selectedMediaItems)
        {
            foreach (MediaFile mfi in selectedMediaItems)
            {
                int episodeNumber = mfi.EpisodeNumber;
                int seasonNumber = mfi.SeasonNumber;

                ISeason seasonToAdd = showDetails[seasonNumber];
                if (seasonToAdd == null)
                {
                    seasonToAdd = AddSeason(seasonNumber);
                }

                if (seasonToAdd != null)
                {
                    IEpisode ep = seasonToAdd[episodeNumber];
                    if (ep != null)
                    {
                        //                        MessageBox.Show("Setting path for Episode " + ep.EpisodeNumber + ": " + ep.Title + " to " + mfi.FileName);
                        if (ep is Episode)
                        {
                            ((Episode)ep).File = mfi;
                        }
                    }
                    else
                    {
                        ep = new Episode(seasonNumber, episodeNumber, null, mfi.EpisodeTitle, null);
                        if (seasonToAdd is Season)
                        {
                            seasonToAdd.Episodes.Add(ep);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Unable to determine any details for season " + seasonNumber);
                }

            }
        }

        /// <summary>
        /// adds the season with the specified season number
        /// </summary>
        /// <param name="seasonNumber">season to add</param>
        /// <returns>the season object that was added</returns>
        private ISeason AddSeason(int seasonNumber)
        {
            foreach (ISeason season in AllSeasons)
            {
                if (season.SeasonNumber == seasonNumber)
                {
                    AddSeason(season);
                    return season;
                }
            }            
            return null;
        }

        /// <summary>
        /// called at the beginning of a drag operation to check if the drag is possible. 
        /// we check to see if there are any media files included in the drag and if there is,
        /// allow it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EpisodeMaintenance_DragEnter(object sender, DragEventArgs e)
        {
            List<string> files = GetMediaFiles(e);
            if (files.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine("Accepting drag with files: " + string.Join(",",files.ToArray()));
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// return true if the filename has an extension of a known video file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool IsVideoFile(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLower();
            return ((ext == ".avi") || (ext == ".mpg"));            
        }

        /// <summary>
        /// examines the drag event args for the list of files and then checks them to
        /// see if there are any media files. if an item in the list of files is actually
        /// a directory, its immediate children are also examined for media files.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected List<string> GetMediaFiles(DragEventArgs e)
        {
            List<string> files = new List<string>();

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    foreach (string fn in data)
                    {
                        if( IsVideoFile(fn) )
                        {
                            files.Add(fn);
                        }
                        else
                        {
                            string[] dirFiles = Directory.GetFiles(fn);
                            foreach (string fn2 in dirFiles)
                            {
                                if( IsVideoFile(fn2) )
                                {
                                    files.Add(fn2);
                                }
                            }
                        }
                    }
                }
            }
            return files;
        }

        private void grdEpisodes_CurrentCellChanged(object sender, EventArgs e)
        {
            int newRowIndex = grdEpisodes.CurrentCellAddress.Y;
            if (newRowIndex != oldEpisodeRowIndex)
            {                
                if (oldEpisodeRowIndex != -1 )
                {
                    if (newRowIndex != -1)
                    {
                        // rebind the episode
                        ISeason season = (ISeason)lstSeasons.SelectedItem;
                        season.Episodes[oldEpisodeRowIndex] = episodeDetails.Episode;
                    }
                }
                if (newRowIndex != -1)
                    episodeDetails.Episode = (Episode)grdEpisodes.CurrentRow.DataBoundItem;
                else
                    episodeDetails.Episode = null;
                oldEpisodeRowIndex = grdEpisodes.CurrentCellAddress.Y;
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if( lstSeasons.SelectedItem == null )
            {
                MessageBox.Show("Select a season first");
            }
            else            
            {
                EpisodeRenamer renamer = new EpisodeRenamer();
                
                List<IEpisode> episodes = new List<IEpisode>();
                ISeason season = (ISeason)lstSeasons.SelectedItem;
                foreach (IEpisode ep in season.Episodes)
                {
                    episodes.Add(ep);
                }
                renamer.Title = showDetails.Title;
                renamer.Episodes = episodes;
                renamer.ShowDialog();
            }            
        }
    }
}
